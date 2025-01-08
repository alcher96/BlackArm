using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackArm.Infrastructure.Configuration;

public class ArmWrestlerConfiguration : IEntityTypeConfiguration<ArmWrestler>
{
    public void Configure(EntityTypeBuilder<ArmWrestler> builder)
    {
        builder.HasData
        (
            new ArmWrestler
            {
                ArmWrestlerId = new Guid("7bb4f59c-dadc-4918-a215-730dd34f03d4"),
                FirstName = "nick",
                LastName = "piterson",
                NickName = "qwerty",
                BirthDate = new DateTime(2023, 10, 1, 12, 0, 0),
                Country = "US",
                Bicep = 40,
                Forearm = 30,
                Weight = 150,
                Height = 120,
                Wins = 15,
                Losses = 2,
            },
            new ArmWrestler
            {
                ArmWrestlerId = new Guid("2d1b391c-92c9-416e-93f8-74ab4fd2a818"),
                FirstName = "john",
                LastName = "doe",
                NickName = "poop",
                BirthDate = new DateTime(2022, 10, 1, 12, 0, 0),
                Country = "US",
                Bicep = 40,
                Forearm = 30,
                Weight = 150,
                Height = 120,
                Wins = 15,
                Losses = 2,
            }
        );
    }
}