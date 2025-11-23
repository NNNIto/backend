using MediatR;

namespace Foodstagram.Application.Posts.GetPostDetail;

public sealed record GetPostDetailQuery(long PostId)
    : IRequest<PostDetailResult>;
