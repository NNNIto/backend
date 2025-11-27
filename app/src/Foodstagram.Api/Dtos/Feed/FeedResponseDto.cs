using System;
using System.Collections.Generic;

namespace Foodstagram.Api.Dtos.Feed;

public sealed class FeedItemDto
{
    public long Id { get; init; }
    public long AuthorId { get; init; }
    public string AuthorName { get; init; } = string.Empty;
    public string AuthorAvatarUrl { get; init; } = string.Empty;
    public string ImageUrl { get; init; } = string.Empty;
    public string Caption { get; init; } = string.Empty;
    public int LikeCount { get; init; }
    public int CommentCount { get; init; }
    public bool IsLiked { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
}

public sealed class FeedResponseDto
{
    public IReadOnlyList<FeedItemDto> Items { get; init; } = Array.Empty<FeedItemDto>();
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
}
