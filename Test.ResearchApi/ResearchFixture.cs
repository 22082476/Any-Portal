using Microsoft.EntityFrameworkCore;
using ResearchApi;

public class ResearchFixture: ResearchContextFixture{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new ResearchContext(options);
        context.Research.AddRange(
            new Research {Title = "ABCD", Compensation = 1.0m, Type_Research = "ABCD", Link_Research = "ABCD", Disability_Type = new List<string>{"ABCD", "ABCD"}},
            new Research {Title = "ABCD", Compensation = 1.0m, Type_Research = "ABCD", Link_Research = "ABCD", Disability_Type = new List<string>{"ABCD", "ABCD"}, Active = true}
        );
        context.SaveChanges();

    }

}
    