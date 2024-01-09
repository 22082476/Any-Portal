
using System.ComponentModel.DataAnnotations;

public class Allowed_AgeRange{

    [Key]
    public int Id {get; set;}
   
    [Required]
    public int ResearchId{get; set;}

    [Required]
    public int Allowed_AgeRangeId{get; set;}
}