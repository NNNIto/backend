using Foodstagram.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodstagram.Infrastructure.Persistence.EntityConfigurations;

public sealed class PostConfig : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("posts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Caption)
            .HasMaxLength(1000);

        builder.HasMany(x => x.Comments)
            .WithOne()
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Likes)
            .WithOne()
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
