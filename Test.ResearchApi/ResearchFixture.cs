using Microsoft.EntityFrameworkCore;
using ResearchApi;

public class ResearchFixture: ResearchContextFixture{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new ResearchContext(options);
        context.Research.AddRange(
            new Research {Title = "ABCD",CompanyId = "1",Company = "Dollef B.V.", Compensation = 1.0m, Type_Research = "ABCD", Link_Research = "ABCD", Disability_Type = new List<string>{"ABCD", "ABCD"}, Description = "descriptie"},
            new Research {Title = "ABCD", CompanyId = "2",Company = "Dollef B.V.", Compensation = 1.0m, Type_Research = "ABCD", Link_Research = "ABCD", Disability_Type = new List<string>{"ABCD", "ABCD"}, Active = true, Description = "descriptie"}
        );
        context.SaveChanges();

    }

}
    