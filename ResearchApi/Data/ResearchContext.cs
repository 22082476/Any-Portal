using Microsoft.EntityFrameworkCore;
namespace ResearchApi;

    public class ResearchContext : DbContext
    {
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Research>()
                .Property(r => r.Active)
                .HasDefaultValue(false);
        }

        public ResearchContext(DbContextOptions options) : base(options){}
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HI0LEOP\\SQLEXPRESS;Database=ResearchApibase;Integrated Security=true;TrustServerCertificate=true;");
        }*/

        public DbSet<Research> Research { get; set; }
        public DbSet<PostalCodeRange> PostalCodeRanges { get; set; }
        public DbSet<Participant> Participants {get; set;}
        public DbSet<Allowed_AgeRange> allowed_AgeRanges {get; set;}
    }
