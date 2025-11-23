using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Posts.ToggleLike;

public sealed class ToggleLikeHandler : IRequestHandler<ToggleLikeCommand>
{
    private readonly IPostRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public ToggleLikeHandler(IPostRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task Handle(ToggleLikeCommand request, CancellationToken cancellationToken)
    {
        await _repository.ToggleLikeAsync(
            request.PostId,
            _currentUser.UserId,
            cancellationToken
        );
    }
}
