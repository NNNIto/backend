using MediatR;

namespace Foodstagram.Application.Posts.GetFeed;

public sealed record GetFeedQuery(int Page, int PageSize)
    : IRequest<GetFeedResult>;
