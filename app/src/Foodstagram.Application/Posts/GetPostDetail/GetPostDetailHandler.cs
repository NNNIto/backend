using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Posts.GetPostDetail;

public sealed class GetPostDetailHandler
    : IRequestHandler<GetPostDetailQuery, PostDetailResult>
{
    private readonly IPostRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public GetPostDetailHandler(IPostRepository repository, ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<PostDetailResult> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
    {
        var post = await _repository.GetPostDetailAsync(
            request.PostId,
            _currentUser.UserId,
            cancellationToken
        );

        var comments = post.Comments.Select(c =>
            new CommentResult(
                c.Id,
                c.UserId,
                c.UserName,
                c.Text,
                c.CreatedAt
            )).ToList();

        return new PostDetailResult(
            post.Id,
            post.AuthorId,
            post.AuthorName,
            post.AuthorAvatarUrl,
            post.ImageUrl,
            post.Caption,
            post.LikeCount,
            post.CommentCount,
            post.IsLiked,
            post.CreatedAt,
            comments
        );
    }
}
