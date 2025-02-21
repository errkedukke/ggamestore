using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.ToTable("OrderDetails");

        builder.HasKey(od => od.Id);

        builder.Property(od => od.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(od => od.Quantity)
            .IsRequired();

        builder.Property(od => od.Discount)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(od => od.Game)
            .WithMany()
            .HasForeignKey(od => od.GameId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
