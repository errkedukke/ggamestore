using Gamestore.Domain;
using Gamestore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Table name (optional)
        builder.ToTable("Orders");

        // Primary Key
        builder.HasKey(o => o.Id);

        // Properties Configuration

        // OrderDate: Required, default value is set in the model
        builder.Property(o => o.OrderDate)
            .IsRequired();

        // OrderStatus: Required, default to `OrderStatus.Open`
        builder.Property(o => o.OrderStatus)
            .IsRequired()
            .HasDefaultValue(OrderStatus.Open);

        // Relationships

        // Customer relationship
        builder.HasOne(o => o.Customer)
            .WithMany() // Assuming no navigation property in User for Orders
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

        // OrderDetails relationship
        builder.HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.NoAction); // Delete order details when an order is deleted
    }
}
