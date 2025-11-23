namespace Foodstagram.Application.Shares.GetShareSuggestions;

public sealed record ShareSuggestionModel(
    long UserId,
    string UserName,
    string DisplayName,
    string AvatarUrl
);
