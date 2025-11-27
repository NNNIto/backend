
namespace Foodstagram.Application.Common.Models;





public sealed record StorySummaryModel(
    long Id,
    long UserId,
    string UserName,
    string AvatarUrl,
    bool IsViewed
);
