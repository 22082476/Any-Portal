using Microsoft.EntityFrameworkCore;

    public class ResearchContext : DbContext
    {
       public ResearchContext(DbContextOptions options) : base(options){}
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Research>()
                .Property(r => r.Active)
                .HasDefaultValue(false);
        }

        public DbSet<Research> Research { get; set; }
        public DbSet<PostalCodeRange> PostalCodeRanges { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Allowed_AgeRange> allowed_AgeRanges { get; set; }
    }
