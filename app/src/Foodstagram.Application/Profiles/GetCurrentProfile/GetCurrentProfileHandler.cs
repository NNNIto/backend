using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Profiles.GetCurrentProfile;

public sealed class GetCurrentProfileHandler
    : IRequestHandler<GetCurrentProfileQuery, ProfileHeaderModel>
{
    private readonly IUserRepository _repository;
    private readonly ICurrentUserService _user;

    public GetCurrentProfileHandler(IUserRepository repository, ICurrentUserService user)
    {
        _repository = repository;
        _user = user;
    }

    public async Task<ProfileHeaderModel> Handle(GetCurrentProfileQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetProfileHeaderAsync(_user.UserId, cancellationToken);
    }
}
