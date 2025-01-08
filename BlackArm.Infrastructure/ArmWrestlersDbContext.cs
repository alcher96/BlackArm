using BlackArm.Domain.Models;
using BlackArm.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BlackArm.Infrastructure;

public class ArmWrestlersDbContext : DbContext
{
    public ArmWrestlersDbContext(DbContextOptions<ArmWrestlersDbContext> options) : base(options)
    {
    }
    
    public System.Data.Entity.DbSet<ArmWrestler> ArmWrestlers { get; set; }
    public System.Data.Entity.DbSet<Competition> Competitions { get; set; }
    public System.Data.Entity.DbSet<WrestlingStyle> WrestlingStyles { get; set; }
    public System.Data.Entity.DbSet<Fight> Fights { get; set; }
    public System.Data.Entity.DbSet<Round> Rounds { get; set; }
    public System.Data.Entity.DbSet<RadarGraph> RadarGraphs { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the one-to-one relationship explicitly (though often inferred)
        modelBuilder.Entity<ArmWrestler>()
            .HasOne(w => w.RadarGraph)
            .WithOne(rg => rg.Wrestler)
            .HasForeignKey<RadarGraph>(rg => rg.WrestlerId); //Key configuration is important

        modelBuilder.ApplyConfiguration(new ArmWrestlerConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}