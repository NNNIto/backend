namespace Foodstagram.Api.Dtos.Profile;

public sealed class ProfileHeaderDto
{
    public long UserId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public string AvatarUrl { get; set; } = string.Empty;

    public int PostCount { get; set; }

    public int FollowerCount { get; set; }

    public int FollowingCount { get; set; }

    public bool IsFollowing { get; set; }
}
