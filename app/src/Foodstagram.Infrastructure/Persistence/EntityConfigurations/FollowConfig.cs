using Foodstagram.Domain.Follows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodstagram.Infrastructure.Persistence.EntityConfigurations;

public sealed class FollowConfig : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder.ToTable("follows");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FollowerId).IsRequired();
        builder.Property(x => x.FolloweeId).IsRequired();

        builder.HasIndex(x => new { x.FollowerId, x.FolloweeId })
            .IsUnique();
    }
}
