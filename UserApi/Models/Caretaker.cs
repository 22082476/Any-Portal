using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Caretaker
{
    [Key] public int CaretakerId { get; set;}
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Email { get; set; }
    [AllowNull] public uint? PhoneNumber { get; set;} 
}