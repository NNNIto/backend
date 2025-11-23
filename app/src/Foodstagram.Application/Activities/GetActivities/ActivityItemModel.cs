namespace Foodstagram.Application.Activities.GetActivities;

public sealed record ActivityItemModel(
    long Id,
    string Type,
    long FromUserId,
    string FromUserName,
    string FromUserAvatarUrl,
    long? PostId,
    DateTimeOffset CreatedAt
);
