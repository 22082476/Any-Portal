using System.ComponentModel.DataAnnotations;

public class AgeRange 
{
    [Key]
    public int AgeId { get; init; }
    public uint AgeStart { get; init; }
    public uint AgeEnd { get; init; }
}