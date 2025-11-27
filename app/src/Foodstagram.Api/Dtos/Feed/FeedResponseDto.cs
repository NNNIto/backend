// src/Foodstagram.Api/Dtos/Feed/FeedResponseDto.cs
namespace Foodstagram.Api.Dtos.Feed;

public sealed class FeedResponseDto
{
    /// <summary>ストーリー一覧</summary>
    public IReadOnlyList<StoryDto> Stories { get; init; } = new List<StoryDto>();

    /// <summary>フィード投稿一覧</summary>
    public IReadOnlyList<FeedItemDto> FeedItems { get; init; } = new List<FeedItemDto>();
}
