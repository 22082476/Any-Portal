using System.ComponentModel.DataAnnotations;

public class AgeRange 
{
    [Key]
    public string RangeName { get; init; }
    public uint AgeStart { get; init; }
    public uint AgeEnd { get; init; }

    public bool CompareAgeRange(AgeRange ageRange)
    {
        return this == ageRange;
    }

    public static bool operator == (AgeRange ageRange, AgeRange ageRange1)
    {
        return ageRange.RangeName.Equals(ageRange1.RangeName) && ageRange1.AgeStart == ageRange1.AgeStart && ageRange.AgeEnd == ageRange1.AgeEnd; 
    }

    public static bool operator != (AgeRange ageRange, AgeRange ageRange1)
    {
        return !ageRange.RangeName.Equals(ageRange1.RangeName) && ageRange1.AgeStart != ageRange1.AgeStart && ageRange.AgeEnd != ageRange1.AgeEnd; 
    }
}