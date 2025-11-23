using MediatR;

namespace Foodstagram.Application.Posts.ToggleLike;

public sealed record ToggleLikeCommand(long PostId) : IRequest;
