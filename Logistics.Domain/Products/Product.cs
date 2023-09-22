using Logistics.Domain.Warehouses;

namespace Logistics.Domain.Products
{
    public class Product
    {
        private readonly List<ProductSupplier> _productSuppliers = new();
        public IReadOnlyCollection<ProductSupplier> ProductSuppliers => _productSuppliers.ToList();

        public IReadOnlyCollection<StockItem> StockItems { get; }
        

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Removed { get; private set; }

        public static Product Create(string name)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            return product;
        }

        public void UpdateInformation(string name)
        {
            Name = name;
        }

        public void AddSupplier(Guid supplierId)
        {
            var productSupplier = new ProductSupplier(Guid.NewGuid(), Id, supplierId);
            _productSuppliers.Add(productSupplier);
        }

        public bool SupplierExists(Guid supplierId)
        {
            return _productSuppliers.Any(x => x.SupplierId == supplierId);
        }

        public void RemoveSupplier(Guid supplierId)
        {
            var productSupplier = _productSuppliers.FirstOrDefault(x => x.SupplierId == supplierId);
            _productSuppliers.Remove(productSupplier);
        }

        public void RemoveProduct()
        {
            _productSuppliers.Clear();
            Removed = true;
        }
    }
}
