using System.ComponentModel.DataAnnotations;

public class Company
{
    [Key] public string UserId { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string CompanyName { get; set; }
    [Required] public string Location { get; set; }
    public Uri? Website { get; set; }
    public string? Description { get; set; }
    [Required] public bool IsValid { get; set; } = false;

}