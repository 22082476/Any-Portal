using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchApi
{
    public class PostalCodeRange
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string From_Postalcode { get; set; }

        [Required]
        public string Till_Postalcode { get; set; }

        // Foreign key naar Research
        public int ResearchId { get; set; }

         [ForeignKey("ResearchId")]
    public Research Research { get; set; } // Navigatie-eigenschap
      
    }
}
