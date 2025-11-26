namespace Foodstagram.Api.Dtos.Feed;

public sealed class StoryDetailDto
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;
    public string ImageUrl { get; init; } = string.Empty; // MediaUrl in backend
    public bool IsViewed { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ExpiresAt { get; init; }
}
