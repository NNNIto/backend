using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Profiles.UpdateProfile;

public sealed class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand>
{
    private readonly IUserRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public UpdateProfileHandler(IUserRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateProfileAsync(
            _currentUser.UserId,
            request.DisplayName,
            request.Bio,
            request.AvatarUrl,
            cancellationToken
        );
    }
}
