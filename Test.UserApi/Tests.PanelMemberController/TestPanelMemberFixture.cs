using Microsoft.EntityFrameworkCore;

public class PanelMemberFixture : UserContextFixture
{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new UserContext(options);
        
        context.PanelMembers.AddRange(
                new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = "0611", FirstName = "Firstname", LastName = "Lastname", AgeId = 1, PostalCode = "2002 ET", Availability = "", Preferred_contact = "not", CaretakerId = "3"},
                new PanelMember { UserId = "userId2", Email = "test323@mail.nl", PhoneNumber = "0611", FirstName = "Firstname12", LastName = "Lastname12", AgeId = 2, PostalCode = "2002 ET", Availability = "", Preferred_contact = "phone"},
                new PanelMember { UserId = "userId3", Email = "test322@mail.nl", PhoneNumber = "0611", FirstName = "Firstname", LastName = "Lastname", AgeId = 3, PostalCode = "2002 ET", Availability = "", Preferred_contact = "mail", CaretakerId = "2"}
            );

        context.AgeRanges.AddRange(
            new AgeRange {AgeId = 1, AgeStart = 1, AgeEnd = 18},
            new AgeRange {AgeId = 2, AgeStart = 18, AgeEnd = 25},
            new AgeRange {AgeId = 3, AgeStart = 25, AgeEnd = 45},
            new AgeRange {AgeId = 4, AgeStart = 45, AgeEnd = 110}
        );

        context.Caretakers.AddRange(
            new Caretaker {CaretakerId = "3", Email = "mail", FirstName = "name", LastName = "name", PhoneNumber = "0"},
            new Caretaker {CaretakerId = "2", Email = "mail", FirstName = "name", LastName = "name", PhoneNumber = "0"}
        );

        context.SaveChanges();    
    }
} 