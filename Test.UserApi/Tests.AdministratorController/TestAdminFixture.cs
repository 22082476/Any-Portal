using Microsoft.EntityFrameworkCore;

public class AdminFixture : UserContextFixture
{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new UserContext(options);
        
        context.Administrators.AddRange(
                new Administrator { UserId = "userId", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", PhoneNumber = "+31 606060", IsAdmin = false },
                new Administrator { UserId = "userId2", Email = "test2@mail.nl", FirstName = "Firstname2", LastName = "Lastname2", PhoneNumber = "+31 606060", IsAdmin = false }
            );
        context.SaveChanges();    
    }
} 