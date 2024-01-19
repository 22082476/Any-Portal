using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Disability
{
    [Key] public string Dcode { get; set; }
    [Required] public string UserId { get; set; }
    [Required] public string Type { get; set; }
    [Required] public string Name { get; set; }
}

public class Tool
{   
    [Key] public int Id { get; set; }
    public string Dcode { get; set; }
    public string UserId { get; set; }

    [Required] public string Name { get; set; }
}