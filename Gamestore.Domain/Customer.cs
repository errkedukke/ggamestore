using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public Guid Id { get; set; }

    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;
}
