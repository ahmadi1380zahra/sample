using Microsoft.EntityFrameworkCore;
using Sample.Entities;

namespace Sample.Persistance.EF;

public class EFDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=zizilast;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>();
        base.OnModelCreating(modelBuilder);
    }
}