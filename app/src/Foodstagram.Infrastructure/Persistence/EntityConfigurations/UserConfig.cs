using Foodstagram.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodstagram.Infrastructure.Persistence.EntityConfigurations;

public sealed class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.DisplayName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Bio)
            .HasMaxLength(200);

        builder.Property(x => x.AvatarUrl)
            .HasMaxLength(300);
    }
}
