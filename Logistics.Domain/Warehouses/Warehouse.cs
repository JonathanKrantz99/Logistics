using Logistics.Domain.Suppliers;

namespace Logistics.Domain.Warehouses
{
    public class Warehouse
    {
        private readonly List<StockItem> _stockItems = new();
        public IReadOnlyCollection<StockItem> StockItems => _stockItems.ToList();


        private readonly List<History> _historyMoved = new();
        public IReadOnlyCollection<History> HistoryMoved => _historyMoved.ToList();


        public IReadOnlyCollection<History> HistoryRecieved;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public bool Removed { get; private set; }

        public static Warehouse Create(string name, Address address)
        {
            var warehouse = new Warehouse
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address
            };

            return warehouse;
        }

        public void UpdateInformation(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public void AddStockItem(Guid productId, Guid supplierId, int quantity)
        {
            var existingStockItem = _stockItems.FirstOrDefault(x => x.ProductId == productId && x.SupplierId == supplierId);

            if (existingStockItem != null)
            {
                existingStockItem.UpdateQuantity(existingStockItem.Quantity + quantity);
            }
            else
            {
                var stockItem = new StockItem(Guid.NewGuid(), Id, productId, supplierId, quantity);

                _stockItems.Add(stockItem);
            }
        }

        public void MoveStockItemQuantity(Guid productId, Guid supplierId, int quantityToMove, Warehouse newWarehouse)
        {
            var stockItem = _stockItems.FirstOrDefault(x => x.ProductId == productId && x.SupplierId == supplierId)!;

            stockItem.UpdateQuantity(stockItem.Quantity - quantityToMove);

            newWarehouse.AddStockItem(productId, supplierId, quantityToMove);

            if (stockItem.Quantity == 0)
            {
                _stockItems.Remove(stockItem);
            }

            _historyMoved.Add(new History(Guid.NewGuid(), Id, newWarehouse.Id, productId, supplierId, quantityToMove));
        }

        public void RemoveStockItemQuantity(Guid productId, Guid supplierId, int quantityToRemove)
        {
            var stockItem = _stockItems.FirstOrDefault(x => x.ProductId == productId && x.SupplierId == supplierId)!;

            stockItem.UpdateQuantity(stockItem.Quantity - quantityToRemove);

            if (stockItem.Quantity == 0)
            {
                _stockItems.Remove(stockItem);
            }
        }

        public void RemoveAllStockItems()
        {
            _stockItems.Clear();
        }

        public void RemoveAllStockItemsByProduct(Guid productId)
        {
            _stockItems.RemoveAll(x => x.ProductId == productId);
        }

        public void RemoveAllStockItemsBySupplier(Guid supplierId)
        {
            _stockItems.RemoveAll(x => x.SupplierId == supplierId);
        }

        public bool StockItemExists(Guid productId, Guid supplierId)
        {
            if (_stockItems.Any(x => x.ProductId == productId && x.SupplierId == supplierId))
            {
                return true;
            }

            return false;
        }

        public bool StockItemQuantityExists(Guid productId, Guid supplierId, int quantity)
        {
            if (_stockItems.Any(x => x.ProductId == productId && x.SupplierId == supplierId && x.Quantity >= quantity))
            {
                return true;
            }

            return false;
        }

        public bool HasStockItems()
        {
            return _stockItems.Any();
        }

        public void RemoveWarehouse()
        {
            Removed = true;
        }
    }
}
