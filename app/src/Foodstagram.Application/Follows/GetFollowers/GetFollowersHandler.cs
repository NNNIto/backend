using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Common.Models;
using MediatR;

namespace Foodstagram.Application.Follows.GetFollowers;

public sealed class GetFollowersHandler
    : IRequestHandler<GetFollowersQuery, IReadOnlyList<UserSummaryModel>>
{
    private readonly IFollowRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public GetFollowersHandler(IFollowRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<IReadOnlyList<UserSummaryModel>> Handle(GetFollowersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetFollowersAsync(_currentUser.UserId, cancellationToken);
    }
}
