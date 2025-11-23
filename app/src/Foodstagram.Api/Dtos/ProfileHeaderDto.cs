// src/Foodstagram.Api/Dtos/Profile/ProfileHeaderDto.cs
namespace Foodstagram.Api.Dtos.Profile;

public sealed class ProfileHeaderDto
{
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;

    public int PostCount { get; init; }
    public int FollowerCount { get; init; }
    public int FollowingCount { get; init; }
}

// src/Foodstagram.Api/Dtos/Profile/ProfilePostDto.cs
namespace Foodstagram.Api.Dtos.Profile;

public sealed class ProfilePostDto
{
    public long Id { get; init; }
    public string ThumbnailUrl { get; init; } = string.Empty;
    public int LikeCount { get; init; }
    public int CommentCount { get; init; }
}

// src/Foodstagram.Api/Dtos/Profile/UpdateProfileRequestDto.cs
namespace Foodstagram.Api.Dtos.Profile;

public sealed class UpdateProfileRequestDto
{
    public string DisplayName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
}
