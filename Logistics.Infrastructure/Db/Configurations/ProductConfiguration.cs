using Logistics.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Infrastructure.Db.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.StockItems)
                   .WithOne()
                   .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductSuppliers)
                   .WithOne()
                   .HasForeignKey(x => x.ProductId);

            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
