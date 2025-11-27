using MediatR;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Follows.GetFollowing;

public sealed record GetFollowingQuery()
    : IRequest<IReadOnlyList<UserSummaryModel>>;
