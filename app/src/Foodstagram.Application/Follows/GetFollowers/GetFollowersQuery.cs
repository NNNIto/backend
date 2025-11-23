using MediatR;

namespace Foodstagram.Application.Follows.GetFollowers;

public sealed record GetFollowersQuery()
    : IRequest<IReadOnlyList<UserSummaryModel>>;
