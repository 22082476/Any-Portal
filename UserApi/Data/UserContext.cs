using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public DbSet<PanelMember> PanelMembers { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<AgeRange> AgeRanges { get; set; }
    
    public UserContext (DbContextOptions options) : base (options)
    {}

}