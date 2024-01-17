using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Administrator
{
    [Key] public string UserId { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [AllowNull] public string? PhoneNumber { get; set; }
    [Required] public bool IsAdmin { get; set; } = false;
}
