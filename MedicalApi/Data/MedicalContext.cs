using Microsoft.EntityFrameworkCore;


public class MedicalContext : DbContext
{
    public MedicalContext (DbContextOptions options) : base (options)
    {}
    
    public DbSet<Disability> Disabilities { get; set; }
    public DbSet<Tool> Tools { get; set; }
}