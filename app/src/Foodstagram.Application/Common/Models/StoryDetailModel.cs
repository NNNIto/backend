namespace Foodstagram.Application.Common.Models;

using System;

public sealed record StoryDetailModel(
    long Id,
    long UserId,
    string UserName,
    string AvatarUrl,
    string MediaUrl,
    string MediaType,
    bool IsViewed,
    DateTimeOffset CreatedAt,
    DateTimeOffset ExpiresAt
);
