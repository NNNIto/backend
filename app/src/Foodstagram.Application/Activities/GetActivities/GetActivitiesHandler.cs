using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Activities.GetActivities;

public sealed class GetActivitiesHandler
    : IRequestHandler<GetActivitiesQuery, IReadOnlyList<ActivityItemModel>>
{
    private readonly IActivityRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public GetActivitiesHandler(IActivityRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<IReadOnlyList<ActivityItemModel>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetActivitiesAsync(_currentUser.UserId, cancellationToken);
    }
}
