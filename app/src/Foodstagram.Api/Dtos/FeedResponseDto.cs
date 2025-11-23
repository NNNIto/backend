// src/Foodstagram.Api/Dtos/Feed/FeedResponseDto.cs
using Foodstagram.Api.Dtos.Feed.Foodstagram.Api.Dtos.Feed;

namespace Foodstagram.Api.Dtos.Feed;

public sealed class FeedResponseDto
{
    public IReadOnlyList<FeedItemDto> Items { get; init; } = Array.Empty<FeedItemDto>();
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
}

// src/Foodstagram.Api/Dtos/Feed/FeedItemDto.cs
namespace Foodstagram.Api.Dtos.Feed;

public sealed class FeedItemDto
{
    public long Id { get; init; }
    public string ImageUrl { get; init; } = string.Empty;
    public string Caption { get; init; } = string.Empty;

    public long AuthorId { get; init; }
    public string AuthorName { get; init; } = string.Empty;
    public string AuthorAvatarUrl { get; init; } = string.Empty;

    public int LikeCount { get; init; }
    public int CommentCount { get; init; }
    public bool IsLiked { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
}

// src/Foodstagram.Api/Dtos/Feed/StoryDto.cs
namespace Foodstagram.Api.Dtos.Feed;

public sealed class StoryDto
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;
    public bool IsViewed { get; init; }
}
