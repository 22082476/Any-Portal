using System.ComponentModel.DataAnnotations;

public class AgeRange 
{
    [Key]
    public string RangeName { get; init; }
    public uint AgeStart { get; init; }
    public uint AgeEnd { get; init; }

    public bool CompareAgeRange(AgeRange ageRange)
    {
        return RangeName.Equals(ageRange.RangeName) && AgeStart == ageRange.AgeStart && AgeEnd == ageRange.AgeEnd;
    }
}