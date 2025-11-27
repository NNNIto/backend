
namespace Foodstagram.Api.Dtos.Activity;

public sealed class ActivityItemDto
{
    public long Id { get; init; }
    public string Type { get; init; } = string.Empty; 
    public long FromUserId { get; init; }
    public string FromUserName { get; init; } = string.Empty;
    public string FromUserAvatarUrl { get; init; } = string.Empty;
    public long? PostId { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
}
