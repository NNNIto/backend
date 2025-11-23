using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Profiles.GetMyPosts;

public sealed class GetMyPostsHandler
    : IRequestHandler<GetMyPostsQuery, IReadOnlyList<MyPostModel>>
{
    private readonly IUserRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public GetMyPostsHandler(IUserRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<IReadOnlyList<MyPostModel>> Handle(GetMyPostsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetMyPostsAsync(_currentUser.UserId, cancellationToken);
    }
}
