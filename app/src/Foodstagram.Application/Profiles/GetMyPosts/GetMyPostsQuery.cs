using MediatR;

namespace Foodstagram.Application.Profiles.GetMyPosts;

public sealed record GetMyPostsQuery()
    : IRequest<IReadOnlyList<MyPostModel>>;
