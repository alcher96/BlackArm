using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackArm.Infrastructure.Configuration;

public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
{
    public void Configure(EntityTypeBuilder<Competition> builder)
    {
        builder.HasData
        (
            new Competition
            {
                CompetitionId = Guid.Parse("2497321b-24e0-4ece-b593-6af1b2f597e2"),
                CompetitionName = "East vs West 1",
                CompetitionDate = new DateTime(2021, 06, 12)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("15b300fd-204f-4cfd-9f87-aea95e24671b"),
                CompetitionName = "East vs West 2",
                CompetitionDate = new DateTime(2022, 02, 12)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("cd12c9d3-eabe-409b-b4d1-2defd56c0d3c"),
                CompetitionName = "East vs West 3",
                CompetitionDate = new DateTime(2022, 05, 21)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("c80cdf25-cc5b-4562-b1fc-8aa367920b8c"),
                CompetitionName = "East vs West 4",
                CompetitionDate = new DateTime(2022, 08, 06)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("152934d5-fd75-4124-84a1-4c5158408f0d"),
                CompetitionName = "East vs West 5",
                CompetitionDate = new DateTime(2022, 11, 19)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("430ba9d5-3cfe-4738-b463-93b286d01f1b"),
                CompetitionName = "East vs West 6",
                CompetitionDate = new DateTime(2023, 01, 21)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("e3d07fcc-6b29-4d22-8e5d-0f2473605c3f"),
                CompetitionName = "East vs West 7",
                CompetitionDate = new DateTime(2023, 05, 06)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("3dc55570-48c0-492c-947d-6212f911a0dd"),
                CompetitionName = "East vs West 8",
                CompetitionDate = new DateTime(2023, 07, 29)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("9f432565-102e-4c07-9a13-04e7bbbc179a"),
                CompetitionName = "East vs West 9",
                CompetitionDate = new DateTime(2023, 08, 26)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("e8a4d2bc-329d-4def-81c5-efeedaf89647"),
                CompetitionName = "East vs West 10",
                CompetitionDate = new DateTime(2023, 11, 11)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("59ac1450-5396-4af5-b2be-493f0c401db1"),
                CompetitionName = "East vs West 11",
                CompetitionDate = new DateTime(2024, 01, 20)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("584ae336-c061-48e9-9146-a774df93eb78"),
                CompetitionName = "East vs West 12",
                CompetitionDate = new DateTime(2024, 04, 20)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("46d3c27f-bfd7-44ed-a0f9-9ff0da8fb7bf"),
                CompetitionName = "East vs West 13",
                CompetitionDate = new DateTime(2024, 07, 06)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("9adb06fd-154a-4069-a8b7-d4f065eb1aef"),
                CompetitionName = "East vs West 14",
                CompetitionDate = new DateTime(2024, 08, 10)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("057fb6df-abfa-4ec9-9f36-280a39cd103d"),
                CompetitionName = "East vs West 15",
                CompetitionDate = new DateTime(2024, 11, 02)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("e11d300e-ec1e-44be-8afd-fd407a6f4678"),
                CompetitionName = "East vs West 16",
                CompetitionDate = new DateTime(2025, 02, 15)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("45886833-0344-4156-92be-371954777b46"),
                CompetitionName = "King of the table 1",
                CompetitionDate = new DateTime(2021, 05, 28)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("ee1aa266-a9f7-40c7-a564-afc38984fc20"),
                CompetitionName = "King of the table 2",
                CompetitionDate = new DateTime(2021, 12, 1)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("70e35538-d797-429f-8d41-ff370e916486"),
                CompetitionName = "King of the table 3",
                CompetitionDate = new DateTime(2022, 04, 02)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("7e472e3f-08a6-4041-aba4-480a389ba7b7"),
                CompetitionName = "King of the table 4",
                CompetitionDate = new DateTime(2022, 06, 25)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("4b14e03e-cb1c-4c3b-ab6d-a50cf2fa6c9a"),
                CompetitionName = "King of the table 5",
                CompetitionDate = new DateTime(2022, 10, 01)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("2e8450a4-717f-4e01-9125-0ccfcb972f1b"),
                CompetitionName = "King of the table 6",
                CompetitionDate = new DateTime(2023, 02, 25)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("10cb5619-5c00-4acd-8ad7-c94b576fac04"),
                CompetitionName = "King of the table 7",
                CompetitionDate = new DateTime(2023, 06, 24)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("35cb0343-5d24-414d-afe2-a9a478178d32"),
                CompetitionName = "King of the table 8",
                CompetitionDate = new DateTime(2023, 09, 23)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("44c6c42f-06bc-43a0-98b7-90038cd9823e"),
                CompetitionName = "King of the table 9",
                CompetitionDate = new DateTime(2023, 12, 09)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("0161d396-4b92-4251-8721-2decbd6cb2db"),
                CompetitionName = "King of the table 10",
                CompetitionDate = new DateTime(2024, 02, 24)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("a685106f-d2e8-4f22-b041-b54144e07410"),
                CompetitionName = "King of the table 11",
                CompetitionDate = new DateTime(2024, 06, 01)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("d9cda1d7-70ef-41c5-a9b0-fc61a2de4688"),
                CompetitionName = "King of the table 12",
                CompetitionDate = new DateTime(2024, 09, 28)
            },
            new Competition
            {
                CompetitionId = Guid.Parse("6eec3665-8ad2-4d3c-819d-d3cf812b02f8"),
                CompetitionName = "King of the table 13",
                CompetitionDate = new DateTime(2024, 12, 14)
            }


        );
    }
}