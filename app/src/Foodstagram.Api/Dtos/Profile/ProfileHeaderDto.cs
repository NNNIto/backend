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

public sealed class UpdateProfileRequestDto
{
    public string DisplayName { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;
}
