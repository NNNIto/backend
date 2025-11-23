namespace Foodstagram.Application.Profiles.GetCurrentProfile;

public sealed record ProfileHeaderModel(
    long UserId,
    string UserName,
    string DisplayName,
    string Bio,
    string AvatarUrl,
    int PostCount,
    int FollowerCount,
    int FollowingCount
);
