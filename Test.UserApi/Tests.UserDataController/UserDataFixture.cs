using Microsoft.EntityFrameworkCore;

public class UserDataFixture : UserContextFixture
{
    protected override void LoadData (DbContextOptions options)
    {
        var context = new UserContext(options);
        context.AgeRanges.AddRange(
        new AgeRange{ AgeId = 1, AgeStart = 1, AgeEnd = 18},
        new AgeRange{ AgeId = 2, AgeStart = 18, AgeEnd = 25},
        new AgeRange{ AgeId = 3, AgeStart = 25, AgeEnd = 45},
        new AgeRange{ AgeId = 4, AgeStart = 45, AgeEnd = 65},
        new AgeRange{ AgeId = 5, AgeStart = 65, AgeEnd = 110}
        );

        context.PanelMembers.AddRange(
        new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = "0611", FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = "", Preferred_contact = "not"},
        new PanelMember { UserId = "userId2", Email = "test323@mail.nl", PhoneNumber = "0611", FirstName = "Firstname12", LastName = "Lastname12", AgeId = 2, PostalCode = "2002 ET", Availability = "", Preferred_contact = "phone"},
        new PanelMember { UserId = "userId3", Email = "test322@mail.nl", PhoneNumber = "0611", FirstName = "Firstname", LastName = "Lastname", AgeId = 3, PostalCode = "2002 ET", Availability = "", Preferred_contact = "mail"}
        );

        context.Companies.AddRange(
            new Company { UserId = "userId5", CompanyName = "CompanyName", Email = "test@mail.nl", Description = "text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true},
            new Company { UserId = "userId4", CompanyName = "CompanyName2", Email = "test2@mail.nl", Description = "text text", Website = new Uri ("https://www.site.nl"), Location = "location", IsValid = true}
            );

        context.Administrators.AddRange(
                new Administrator { UserId = "userId6", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", PhoneNumber = "+31 606060", IsAdmin = false },
                new Administrator { UserId = "userId7", Email = "test2@mail.nl", FirstName = "Firstname2", LastName = "Lastname2", PhoneNumber = "+31 606060", IsAdmin = true }
            );

        context.SaveChanges();
    }
}