using System.ComponentModel.DataAnnotations;

public class Research
{
    [Key]
    public int Rcode { get; set; }

    [Required]
    public string CompanyId{ get; set; }
     [Required]
    public string Company{ get; set; }

    public bool Active { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public decimal Compensation { get; set; }

    [Required]
    public string Type_Research { get; set; }
    public string Link_Research { get; set; }

    public string Description { get; set; }

    public IList<string>? Disability_Type { get; set; }
}
