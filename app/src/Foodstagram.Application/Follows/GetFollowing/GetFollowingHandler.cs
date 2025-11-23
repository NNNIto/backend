using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Common.Models;
using MediatR;

namespace Foodstagram.Application.Follows.GetFollowing;

public sealed class GetFollowingHandler
    : IRequestHandler<GetFollowingQuery, IReadOnlyList<UserSummaryModel>>
{
    private readonly IFollowRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public GetFollowingHandler(IFollowRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<IReadOnlyList<UserSummaryModel>> Handle(GetFollowingQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetFollowingAsync(_currentUser.UserId, cancellationToken);
    }
}
