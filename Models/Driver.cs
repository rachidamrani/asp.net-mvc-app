using System.ComponentModel.DataAnnotations;

namespace MvcCrudApp.Models;

public class Driver
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required(ErrorMessage = "Driver's first name is required.")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Driver's last name is required.")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Driver's email is required.")]
    public required string Email { get; set; }
}