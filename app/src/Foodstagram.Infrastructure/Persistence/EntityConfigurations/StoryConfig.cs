using Foodstagram.Domain.Stories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodstagram.Infrastructure.Persistence.EntityConfigurations;

public sealed class StoryConfig : IEntityTypeConfiguration<Story>
{
    public void Configure(EntityTypeBuilder<Story> builder)
    {
        builder.ToTable("stories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(300)
            .IsRequired();

        builder.HasMany(x => x.Views)
            .WithOne()
            .HasForeignKey(v => v.StoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
