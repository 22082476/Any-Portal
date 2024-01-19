using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class PanelMember
{
    [Key] public string UserId { get; set; }
    public string? Email { get; set; }
    [AllowNull] public string? PhoneNumber { get; set;}
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [Required] public int AgeId { get; set; }

    [Required] public string PostalCode { get; set; }

    [Required] public string Preferred_contact { get; set; }  
    [Required] public string Availability { get; set; }
    public string? CaretakerId { get; set;}

    public void UpdateToNull()
    {
        FirstName = null;
        LastName = null;
        Email = null;
        PhoneNumber = null;
        Preferred_contact = "";
        Availability = "Niet";
        CaretakerId = null;
    }
}