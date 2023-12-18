using Microsoft.EntityFrameworkCore;

public class UserDataFixture : UserContextFixture
{
    protected override void LoadData (DbContextOptions options)
    {
        var context = new UserContext(options);
        context.AgeRanges.AddRange(
        new AgeRange{ RangeName = "Range1", AgeStart = 1, AgeEnd = 18},
        new AgeRange{ RangeName = "Range2", AgeStart = 18, AgeEnd = 25},
        new AgeRange{ RangeName = "Range3", AgeStart = 25, AgeEnd = 45},
        new AgeRange{ RangeName = "Range4", AgeStart = 45, AgeEnd = 65},
        new AgeRange{ RangeName = "Range5", AgeStart = 65, AgeEnd = 110}
        );

        context.PanelMembers.AddRange(
        new PanelMember { UserId = "userId", Email = "test@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", Age = new AgeRange {RangeName = "range1", AgeStart = 1, AgeEnd = 18}, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "not"},
        new PanelMember { UserId = "userId2", Email = "test323@mail.nl", PhoneNumber = 0611, FirstName = "Firstname12", LastName = "Lastname12", Age = new AgeRange {RangeName = "range2", AgeStart = 18, AgeEnd = 35}, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "phone"},
        new PanelMember { UserId = "userId3", Email = "test322@mail.nl", PhoneNumber = 0611, FirstName = "Firstname", LastName = "Lastname", Age = new AgeRange {RangeName = "range3", AgeStart = 35, AgeEnd = 55}, PostalCode = "2002 ET", Availability = new [] {"", "", "", "", "", "", ""}, Preferred_contact = "mail"}
        );

        context.SaveChanges();
    }
}