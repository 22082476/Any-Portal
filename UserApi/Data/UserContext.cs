using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public DbSet<PanelMember> PanelMembers { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<AgeRange> AgeRanges { get; set; }

    public DbSet<Caretaker> Caretakers { get; set; }
    
    public UserContext (DbContextOptions options) : base (options)
    {}

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caretaker>()
            .Property(e => e.CaretakerId) // Vervang "YourIdProperty" door de werkelijke naam van je ID-eigenschap
            .ValueGeneratedNever(); // Hiermee wordt aangegeven dat de waarde niet automatisch gegenereerd moet worden
    }
}