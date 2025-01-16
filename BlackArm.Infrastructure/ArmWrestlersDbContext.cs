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
        
        
        // Fights as Wrestler1
        // modelBuilder.Entity<ArmWrestler>()
        //     .HasMany(w => w.FightsAsWrestler1)
        //     .WithOne(f => f.Wrestler1)
        //     .HasForeignKey(f => f.Wrestler1Id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // // Fights as Wrestler2
        // modelBuilder.Entity<ArmWrestler>()
        //     .HasMany(w => w.FightsAsWrestler2)
        //     .WithOne(f => f.Wrestler2)
        //     .HasForeignKey(f => f.Wrestler2Id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // // Fights won
        // modelBuilder.Entity<ArmWrestler>()
        //     .HasMany(w => w.FightsWon)
        //     .WithOne(f => f.Winner)
        //     .HasForeignKey(f => f.WinnerId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // // Rounds won
        // modelBuilder.Entity<ArmWrestler>()
        //     .HasMany(w => w.RoundsWon)
        //     .WithOne(r => r.Winner)
        //     .HasForeignKey(r => r.WinnerId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // // Competition Configuration
        // modelBuilder.Entity<Competition>()
        //     .HasMany(c => c.Fights)
        //     .WithOne(f => f.Competition)
        //     .HasForeignKey(f => f.CompetitionId)
        //     .OnDelete(DeleteBehavior.Cascade);
        //
        // // WrestlingStyle Configuration
        // modelBuilder.Entity<WrestlingStyle>()
        //     .HasMany(ws => ws.FightsUsingStyle)
        //     .WithOne(f => f.StyleUsed)
        //     .HasForeignKey(f => f.StyleUsedId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<WrestlingStyle>()
        //     .HasMany(ws => ws.RoundsUsingStyle)
        //     .WithOne(r => r.StyleUsed)
        //     .HasForeignKey(r => r.StyleUsedId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // // Fight Configuration
        // modelBuilder.Entity<Fight>()
        //     .HasMany(f => f.Rounds)
        //     .WithOne(r => r.Fight)
        //     .HasForeignKey(r => r.FightId)
        //     .OnDelete(DeleteBehavior.Cascade);


        // Round Configuration
       // modelBuilder.Entity<Round>()
        //    .HasCheckConstraint("CK_Round_RoundNumber", "[RoundNumber] >= 1 AND [RoundNumber] <= 6");

        modelBuilder.ApplyConfiguration(new ArmWrestlerConfiguration());
        modelBuilder.ApplyConfiguration(new WrestlingStyleConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}