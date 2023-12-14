

using System.ComponentModel.DataAnnotations;
namespace ResearchApi{
public class Research{
    [Key]
    public int Rcode{get; set;}
    [Required]
    public string Title{get; set;}

    [Required]
    public Decimal Compensation {get; set;}
    [Required]
    public string Type_Research{get; set;}
    [Required]
    public string Link_Research{get; set;}
    public IList<string> Disabillity_Type{get; set;}
    public IList<string> Participant{get; set;}
    [Required]
    public IList<int> Allowed_AgeRange{get; set;}
    
    
}


}