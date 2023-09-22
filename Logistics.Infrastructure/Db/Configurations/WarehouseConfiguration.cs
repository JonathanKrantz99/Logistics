using Logistics.Domain.Warehouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logistics.Infrastructure.Db.Configurations
{
    internal class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.StockItems)
                   .WithOne()
                   .HasForeignKey(x => x.WarehouseId);

            builder.HasMany(x => x.HistoryMoved).WithOne().HasForeignKey(x => x.SourceWarehouseId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.HistoryRecieved).WithOne().HasForeignKey(x => x.TargetWarehouseId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Name).HasMaxLength(256);

            builder.OwnsOne(x => x.Address);
        }
    }
}
