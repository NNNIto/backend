using MediatR;

namespace Foodstagram.Application.Activities.GetActivities;

public sealed record GetActivitiesQuery()
    : IRequest<IReadOnlyList<ActivityItemModel>>;
