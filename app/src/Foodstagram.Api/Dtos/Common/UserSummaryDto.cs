namespace Foodstagram.Api.Dtos.Common;

public sealed class UserSummaryDto
{
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;
}
