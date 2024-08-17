using Gamestore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public OrderStatus OrderStatus { get; set; }

    [Required]
    public decimal Sum { get; set; }

    public DateTime? PaidDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public Guid? EmployeeId { get; set; }

    public int? ShipVia { get; set; }

    public double? Freigh { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }
}
