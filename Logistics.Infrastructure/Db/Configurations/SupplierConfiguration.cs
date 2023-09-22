using Logistics.Domain.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Infrastructure.Db.Configurations
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ProductSuppliers)
                   .WithOne()
                   .HasForeignKey(x => x.SupplierId);

            builder.Property(x => x.Name).HasMaxLength(256);
        }
    }
}
