using System.ComponentModel.DataAnnotations;

public class PanelMember
{
    [Key]
    public string UserId { get; set; }
    [Required]
    public string Email { get; set; }
    public uint PhoneNumber { get; set;}
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    [Required]
    public AgeRange Age { get; set; }

    [Required]
    public string postalCode { get; set; }

    public string Preferred_contact { get; set; }  
    public string [] Availability = new string[7];

}