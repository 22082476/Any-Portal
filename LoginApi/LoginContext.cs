using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoginApi
{
    public class LoginContext : IdentityDbContext<IdentityUser>
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

    }
}