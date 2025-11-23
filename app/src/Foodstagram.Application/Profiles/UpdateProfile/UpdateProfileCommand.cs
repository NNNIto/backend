using MediatR;

namespace Foodstagram.Application.Profiles.UpdateProfile;

public sealed record UpdateProfileCommand(
    string DisplayName,
    string Bio,
    string AvatarUrl
) : IRequest;
