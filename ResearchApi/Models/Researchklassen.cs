

using System.ComponentModel.DataAnnotations;
namespace ResearchApi;


  public class Research
    {
        [Key]
        public int Rcode { get; set; }

        
        public bool Active {get; set;}

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Compensation { get; set; }

        [Required]
        public string Type_Research { get; set; }

        [Required]
        public string Link_Research { get; set; }

      
         public IList<string>? Disability_Type { get; set; } 
  
    }
