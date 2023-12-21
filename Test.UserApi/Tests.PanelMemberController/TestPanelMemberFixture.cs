using Microsoft.EntityFrameworkCore;

public class PanelMemberFixture : UserContextFixture
{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new UserContext(options);
        
        context.PanelMembers.AddRange(
                new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"},
                new PanelMember { UserId = "userId2", Email = "test323@mail.nl", PhoneNumber = 0611, FirstName = "Firstname12", LastName = "Lastname12", AgeId = 2, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "phone"},
                new PanelMember { UserId = "userId3", Email = "test322@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", AgeId = 3, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "mail"}
            );

        context.AgeRanges.AddRange(
            new AgeRange {AgeId = 1, AgeStart = 1, AgeEnd = 18},
            new AgeRange {AgeId = 2, AgeStart = 18, AgeEnd = 25},
            new AgeRange {AgeId = 3, AgeStart = 25, AgeEnd = 45},
            new AgeRange {AgeId = 4, AgeStart = 45, AgeEnd = 110}
        );
        context.SaveChanges();    
    }
} 