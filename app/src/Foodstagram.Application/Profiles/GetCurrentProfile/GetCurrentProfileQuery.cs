
using MediatR;

namespace Foodstagram.Application.Profiles.GetCurrentProfile;




public sealed record GetCurrentProfileQuery()
    : IRequest<ProfileHeaderModel>;
