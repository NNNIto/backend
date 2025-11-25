namespace Foodstagram.Api.Dtos.Feed;

public sealed class FeedResponseDto
{
    public IReadOnlyList<FeedItemDto> Items { get; init; } = Array.Empty<FeedItemDto>();
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
}
