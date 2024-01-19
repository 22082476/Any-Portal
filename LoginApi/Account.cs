using System.ComponentModel.DataAnnotations;

namespace LoginApi;

public class Account
{
    [Key]
    public string UserId { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get;set; }
}