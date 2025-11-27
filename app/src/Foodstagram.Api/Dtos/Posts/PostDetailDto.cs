using System;
using System.Collections.Generic;

namespace Foodstagram.Api.Dtos.Posts;

public sealed class CommentDto
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public DateTimeOffset CreatedAt { get; init; }
}

public sealed class PostDetailDto
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
    public IReadOnlyList<CommentDto> Comments { get; init; } = Array.Empty<CommentDto>();
}
