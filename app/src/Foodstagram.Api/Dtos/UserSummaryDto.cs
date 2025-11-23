// src/Foodstagram.Api/Dtos/Common/UserSummaryDto.cs
namespace Foodstagram.Api.Dtos.Common;

public sealed class UserSummaryDto
{
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;
}

// src/Foodstagram.Api/Dtos/Common/PagedResultDto.cs
namespace Foodstagram.Api.Dtos.Common;

public sealed class PagedResultDto<T>
{
    public IReadOnlyList<T> Items { get; init; } = Array.Empty<T>();
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
}
