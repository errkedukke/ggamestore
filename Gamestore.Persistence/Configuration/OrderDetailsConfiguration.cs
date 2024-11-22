using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        // Table name (optional)
        builder.ToTable("OrderDetails");

        // Primary Key
        builder.HasKey(od => od.Id);

        // Properties Configuration

        // UnitPrice: Required, decimal precision and scale
        builder.Property(od => od.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // Quantity: Required, default value is set in the model
        builder.Property(od => od.Quantity)
            .IsRequired();

        // Discount: Optional, decimal precision and scale
        builder.Property(od => od.Discount)
            .HasColumnType("decimal(18,2)");

        // Relationships

        // Game relationship
        builder.HasOne(od => od.Game)
            .WithMany() // Assuming no navigation property in Game for OrderDetails
            .HasForeignKey(od => od.GameId)
            .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

        // Order relationship
        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.NoAction); // Delete order details when an order is deleted
    }
}
