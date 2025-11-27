using MediatR;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Follows.GetFollowers;

public sealed record GetFollowersQuery()
    : IRequest<IReadOnlyList<UserSummaryModel>>;
