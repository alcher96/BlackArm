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
                StyleId = Guid.Parse("8e66d889-7055-4024-b9d6-58732c3bddd0"),
                StyleName = "Top roll",
            },
            new WrestlingStyle
            {
                StyleId = Guid.Parse("ad870477-c1c7-4310-b512-944e68b4a894"),
                StyleName = "Hook",
            },
            new WrestlingStyle
            {
                StyleId = Guid.Parse("71d60165-142c-47a5-aeba-265d771cfbea"),
                StyleName = "Kings move",
            }
        );
    }
}