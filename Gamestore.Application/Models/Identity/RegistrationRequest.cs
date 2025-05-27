using System.ComponentModel.DataAnnotations;

namespace Gamestore.Application.Models.Identity;

public class RegistrationRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }

    [Required]
    [MinLength(6)]
    public string Username { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}

