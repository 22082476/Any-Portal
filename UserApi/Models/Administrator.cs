using System.ComponentModel.DataAnnotations;

public class Administrator
{
    [Key] public string UserId { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }

    [Required] public bool IsAdmin { get; set; } = false;
    
}
