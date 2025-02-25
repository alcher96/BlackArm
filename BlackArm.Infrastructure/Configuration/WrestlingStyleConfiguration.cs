using BlackArm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackArm.Infrastructure.Configuration;

public class WrestlingStyleConfiguration : IEntityTypeConfiguration<WrestlingStyle>
{
    public void Configure(EntityTypeBuilder<WrestlingStyle> builder)
    {
        builder.HasData(
            new WrestlingStyle
            {
                StyleId = Guid.Parse("8e4fae11-a3e3-485f-88b3-cd76cfb50985"),
                StyleName = "Top roll"
            },
            new WrestlingStyle
            {
                StyleId = Guid.Parse("81a1f66f-09f9-4ab4-a18d-93bc5396ff15"),
                StyleName = "Hook"
            },
            new WrestlingStyle
            {
                StyleId = Guid.Parse("2d2e9652-59d2-4933-acb3-69f741ad2c2b"),
                StyleName = "Kings move"
            }
        );
    }
}