using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Posts.GetFeed;

public sealed class GetFeedHandler : IRequestHandler<GetFeedQuery, GetFeedResult>
{
    private readonly IPostRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public GetFeedHandler(IPostRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<GetFeedResult> Handle(GetFeedQuery request, CancellationToken cancellationToken)
    {
        var (items, total) = await _repository.GetFeedAsync(
            userId: _currentUser.UserId,
            page: request.Page,
            pageSize: request.PageSize,
            cancellationToken
        );

        var mapped = items.Select(x => new FeedItemResult(
            x.Id,
            x.AuthorId,
            x.AuthorName,
            x.AuthorAvatarUrl,
            x.ImageUrl,
            x.Caption,
            x.LikeCount,
            x.CommentCount,
            x.IsLiked,
            x.CreatedAt
        )).ToList();

        return new GetFeedResult(mapped, request.Page, request.PageSize, total);
    }
}
