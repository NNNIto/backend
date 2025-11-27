// src/Foodstagram.Api/Dtos/Posts/PostDetailDto.cs
namespace Foodstagram.Api.Dtos.Posts;

public sealed class PostDetailDto
{
    public long Id { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public string Caption { get; set; } = string.Empty;

    public int LikeCount { get; set; }

    public bool IsLiked { get; set; }

    public int CommentCount { get; set; }

    public DateTime CreatedAt { get; set; }

    /// <summary>投稿者名</summary>
    public string AuthorName { get; set; } = string.Empty;

    /// <summary>投稿者のアイコン URL</summary>
    public string AuthorAvatarUrl { get; set; } = string.Empty;

    /// <summary>コメント一覧</summary>
    public IReadOnlyList<CommentDto> Comments { get; set; } = new List<CommentDto>();
}
