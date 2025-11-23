// src/Foodstagram.Api/Dtos/Feed/PostDetailDto.cs
using Foodstagram.Api.Dtos.Feed.Foodstagram.Api.Dtos.Feed;

namespace Foodstagram.Api.Dtos.Feed;

public sealed class PostDetailDto
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

    public IReadOnlyList<CommentDto> Comments { get; init; } = Array.Empty<CommentDto>();
}

// src/Foodstagram.Api/Dtos/Feed/CommentDto.cs
namespace Foodstagram.Api.Dtos.Feed;

public sealed class CommentDto
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public DateTimeOffset CreatedAt { get; init; }
}
