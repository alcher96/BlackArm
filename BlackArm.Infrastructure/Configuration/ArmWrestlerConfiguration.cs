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
                SidePressure = 6,
                Wrist = 8,
                Stamina = 5,
                Pronaton = 4,
                Angle = 5
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
                SidePressure = 3,
                Wrist = 2,
                Stamina = 6,
                Pronaton = 6,
                Angle = 7
            },
            new ArmWrestler
            {
                ArmWrestlerId = new Guid("cd9bc134-1c3c-4beb-89b8-fac7a147446e"),
                FirstName = "Sho",
                LastName = "Mik",
                NickName = ".Net BackEnd",
                BirthDate = new DateTime(1920, 12, 1, 12, 0, 0),
                Country = "RU",
                Bicep = 50,
                Forearm = 50,
                Weight = 150,
                Height = 120,
                Wins = 99,
                Losses = 0,
                SidePressure = 10,
                Wrist = 10,
                Stamina = 10,
                Pronaton = 10,
                Angle = 10
            },
            new ArmWrestler
            {
                ArmWrestlerId = new Guid("f418d8ec-34ce-4992-be94-d7a65b2ac45f"),
                FirstName = "Dave",
                LastName = "Chaffee",
                NickName = "",
                BirthDate = new DateTime(1974, 12, 1, 12, 0, 0),
                Country = "US",
                Bicep = 50,
                Forearm = 46,
                Weight = 150,
                Height = 110,
                Wins = 18,
                Losses = 4,
                SidePressure = 8,
                Wrist = 8,
                Stamina = 6,
                Pronaton = 7,
                Angle = 8
            },
            new ArmWrestler
            {
                ArmWrestlerId = new Guid("f5f125b5-7f67-4d1a-945a-987e6b8d50a3"),
                FirstName = "Leonidas",
                LastName = "Arcona",
                NickName = "UpSad",
                BirthDate = new DateTime(2000, 12, 1, 12, 0, 0),
                Country = "EU",
                Bicep = 55,
                Forearm = 49,
                Weight = 180,
                Height = 105,
                Wins = 4,
                Losses = 3,
                SidePressure = 6,
                Wrist = 5,
                Stamina = 5,
                Pronaton = 5,
                Angle = 4
            }
        );
    }
}