using Microsoft.EntityFrameworkCore;

public class CompanyFixture : UserContextFixture
{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new UserContext(options);
       
        context.Companies.AddRange(
            new Company { UserId = "userId", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true},
            new Company { UserId = "userId2", CompanyName = "CompanyName2", Email = "test2@mail.nl", Description = "text text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true}
            );
        context.SaveChanges();    
    }
} 