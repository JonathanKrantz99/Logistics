using Logistics.Domain.Products;

namespace Logistics.Domain.Suppliers
{
    public class Supplier
    {
        public IReadOnlyCollection<ProductSupplier> ProductSuppliers { get; }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Removed { get; private set; }

        public static Supplier Create(string name)
        {
            var supplier = new Supplier
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            return supplier;
        }

        public void UpdateInformation(string name)
        {
            Name = name;
        }

        public void RemoveSupplier()
        {
            Removed = true;
        }
    }
}
