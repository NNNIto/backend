
namespace Foodstagram.Application.Common.Models;





public sealed record UserSummaryModel(
    long UserId,
    string UserName,
    string DisplayName,
    string AvatarUrl
);
