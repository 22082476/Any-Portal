using System.ComponentModel.DataAnnotations;


public class Participant{

    [Key]
    public int Id{get; set;}

    [Required]
    public int ResearchId{get; set;}

    [Required]
    public string UserId{get; set;}

}