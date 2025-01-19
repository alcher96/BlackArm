using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackArm.Infrastructure.Configuration;

public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
{
    public void Configure(EntityTypeBuilder<Competition> builder)
    {
        builder.HasData(
            new Competition
            {
                CompetitionId = Guid.Parse("e85a1433-87bc-42b5-85c4-1c9bc2ac66fc"),
                CompetitionName = "King of the table 1",
                CompetitionDate = new DateTime(2018, 8, 1)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("dfc6e35c-6057-4fa6-8c55-5332bb19d357"),
                CompetitionName = "East vs West 1",
                CompetitionDate = new DateTime(2019, 8, 1)
            }
        );
    }
}