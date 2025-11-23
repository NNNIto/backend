using MediatR;

namespace Foodstagram.Application.Profiles.GetMyPosts;

public sealed record GetMyPostsQuery(int page)
    : IRequest<IReadOnlyList<MyPostModel>>;
