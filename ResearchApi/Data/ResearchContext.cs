using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ResearchApi{
public class ResearchContext: DbContext{
    public DbSet<Research> Research {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
    
          optionsBuilder.UseSqlServer("Server=DESKTOP-HI0LEOP\\SQLEXPRESS;Database=ResearchApibase;Integrated Security=true;TrustServerCertificate=true;");

}

}