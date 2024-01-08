using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApi;

public class Disability
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Dcode { get; set; }
    public required string UserId { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }

    public string? Tool { get; set; }
}