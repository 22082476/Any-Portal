using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchApi;
    public class PostalCodeRange
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string From_Postalcode { get; set; }

        [Required]
        public string Till_Postalcode { get; set; }

       [Required]
        public int ResearchId { get; set; }
    }
