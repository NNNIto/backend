namespace Foodstagram.Application.Posts.GetFeed;

public sealed record FeedItemResult(
    long Id,
    long AuthorId,
    string AuthorName,
    string AuthorAvatarUrl,
    string ImageUrl,
    string Caption,
    int LikeCount,
    int CommentCount,
    bool IsLiked,
    DateTimeOffset CreatedAt
);

public sealed record GetFeedResult(
    IReadOnlyList<FeedItemResult> Items,
    int Page,
    int PageSize,
    int TotalCount
);
