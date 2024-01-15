using Microsoft.EntityFrameworkCore;

namespace MedicalApi;

// Represents the database context for managing interactions with the underlying database.
public class DisabilityDbContext : DbContext
{
    // Constructor that takes DbContextOptions as a parameter, allowing dependency injection.
    // This constructor is typically used for configuring the database connection and other options.
    public DisabilityDbContext(DbContextOptions<DisabilityDbContext> options)
    :base(options)
    {
    }
    
    // DbSet property representing the table or collection of "Disabilities" in the database.
    // This property will be used for querying and updating the Disability entities.
    // DbSet provides a set of data access methods for the specified entity type.
    public DbSet<Disability> Disabilities { get; set; }
}