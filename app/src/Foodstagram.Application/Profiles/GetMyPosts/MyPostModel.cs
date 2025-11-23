namespace Foodstagram.Application.Profiles.GetMyPosts;

public sealed record MyPostModel(
    long Id,
    string ThumbnailUrl,
    int LikeCount,
    int CommentCount
);
