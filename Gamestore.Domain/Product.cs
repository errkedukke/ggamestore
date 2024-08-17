using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(Category))]
    public Guid CategoryID { get; set; }

    public string? QuantityPerUnit { get; set; }

    public double? UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }

    public int? UnitsOnOrder { get; set; }

    public int? ReorderLevel { get; set; }

    public bool? Discontinued { get; set; }
}
