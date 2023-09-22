using Logistics.Domain.Products;
using Logistics.Domain.Suppliers;
using Logistics.Domain.Warehouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Logistics.Infrastructure.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<StockItem> StockItem { get; set; }
        public DbSet<History> History { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server={server};Database=Logistics;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            var warehouse1 = new { Id = Guid.NewGuid(), Name = "Warehouse 1", Removed = false };
            var warehouse2 = new { Id = Guid.NewGuid(), Name = "Warehouse 2", Removed = false };

            var product1 = new { Id = Guid.NewGuid(), Name = "Keyboard", Removed = false };
            var product2 = new { Id = Guid.NewGuid(), Name = "Headset", Removed = false };
            var product3 = new { Id = Guid.NewGuid(), Name = "Monitor", Removed = false };

            var supplier1 = new { Id = Guid.NewGuid(), Name = "Supplier 1", Removed = false };
            var supplier2 = new { Id = Guid.NewGuid(), Name = "Supplier 2", Removed = false };

            modelBuilder.Entity<Supplier>().HasData(supplier1, supplier2);
            modelBuilder.Entity<Product>().HasData(product1, product2, product3);
            modelBuilder.Entity<Warehouse>().HasData(warehouse1, warehouse2);

            modelBuilder.Entity<Warehouse>().OwnsOne(x => x.Address).HasData(
                new
                {
                    WarehouseId = warehouse1.Id,
                    Street = "Träslövsvägen",
                    StreetNumber = "171G",
                    City = "Varberg",
                    PostalCode = "43237"
                },
                new
                {
                    WarehouseId = warehouse2.Id,
                    Street = "Föreningsgatan",
                    StreetNumber = "56",
                    City = "Varberg",
                    PostalCode = "43236"
                }
                );

            modelBuilder.Entity<ProductSupplier>().HasData(
                new { Id = Guid.NewGuid(), ProductId = product1.Id, SupplierId = supplier1.Id },
                new { Id = Guid.NewGuid(), ProductId = product2.Id, SupplierId = supplier1.Id },
                new { Id = Guid.NewGuid(), ProductId = product3.Id, SupplierId = supplier2.Id }
                );

            modelBuilder.Entity<StockItem>().HasData(
                new { Id = Guid.NewGuid(), WarehouseId = warehouse1.Id, ProductId = product1.Id, SupplierId = supplier1.Id, Quantity = 40 },
                new { Id = Guid.NewGuid(), WarehouseId = warehouse1.Id, ProductId = product2.Id, SupplierId = supplier1.Id, Quantity = 50 },
                new { Id = Guid.NewGuid(), WarehouseId = warehouse2.Id, ProductId = product3.Id, SupplierId = supplier2.Id, Quantity = 200 }
                );
        }
    }
}
