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
        
        
        //
        // Configure the relationship between Fight and Wrestler (Wrestler1)
        modelBuilder.Entity<Fight>()
            .HasOne(f => f.Wrestler1)
            .WithMany(w => w.FightsAsWrestler1)
            .HasForeignKey(f => f.Wrestler1Id);

        // Configure the relationship between Fight and Wrestler (Wrestler2)
        modelBuilder.Entity<Fight>()
            .HasOne(f => f.Wrestler2)
            .WithMany(w => w.FightsAsWrestler2)
            .HasForeignKey(f => f.Wrestler2Id);

        // Configure the relationship between Fight and Wrestler (Winner)
        modelBuilder.Entity<Fight>()
            .HasOne(f => f.Winner)
            .WithMany(w => w.FightsWon)
            .HasForeignKey(f => f.WinnerId);

        // Configure the relationship between Round and Wrestler (Winner)
        modelBuilder.Entity<Round>()
            .HasOne(r => r.Winner)
            .WithMany(w => w.RoundsWon)
            .HasForeignKey(r => r.WinnerId);
        

        modelBuilder.ApplyConfiguration(new ArmWrestlerConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}