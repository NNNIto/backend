namespace Foodstagram.Api.Dtos.Feed;

public sealed class StoryDto
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;
    public bool IsViewed { get; init; }
}
