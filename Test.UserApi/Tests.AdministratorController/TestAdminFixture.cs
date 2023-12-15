using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

public class AdminFixture : UserContextFixture
{
    protected override void LoadData(DbContextOptions options)
    {
        var context = new UserContext(options);
        
        context.Administrators.AddRange(
                new Administrator { UserId = "userId", Email = "test@mail.nl", FirstName = "Firstname", LastName = "Lastname", IsAdmin = false },
                new Administrator { UserId = "userId2", Email = "test2@mail.nl", FirstName = "Firstname2", LastName = "Lastname2", IsAdmin = false }
            );
        context.SaveChanges();    
    }
} 