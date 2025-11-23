namespace Foodstagram.Application.Posts.GetPostDetail;

public sealed record CommentResult(
    long Id,
    long UserId,
    string UserName,
    string Text,
    DateTimeOffset CreatedAt
);

public sealed record PostDetailResult(
    long Id,
    long AuthorId,
    string AuthorName,
    string AuthorAvatarUrl,
    string ImageUrl,
    string Caption,
    int LikeCount,
    int CommentCount,
    bool IsLiked,
    DateTimeOffset CreatedAt,
    IReadOnlyList<CommentResult> Comments
);
