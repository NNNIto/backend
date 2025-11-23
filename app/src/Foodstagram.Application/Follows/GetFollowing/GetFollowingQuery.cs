using MediatR;

namespace Foodstagram.Application.Follows.GetFollowing;

public sealed record GetFollowingQuery()
    : IRequest<IReadOnlyList<UserSummaryModel>>;
