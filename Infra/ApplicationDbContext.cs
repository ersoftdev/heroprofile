using _Hero = Hero.Domain.Hero.Heroes;
using Microsoft.EntityFrameworkCore;
using Hero.Domain.Hero.Heroes;

namespace Hero.Infra.Repositories;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options)
{
    public DbSet<_Hero.Hero> Heroes { get; set; }
    public DbSet<_Hero.Herotype> Herotype { get; set; }
    public DbSet<_Hero.Heroattributes> Attributes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Heroattributes>(eb =>
        {
            eb.HasNoKey();
        });
    }
}
