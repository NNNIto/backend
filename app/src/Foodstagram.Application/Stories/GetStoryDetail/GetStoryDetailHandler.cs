
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Stories.GetStoryDetail;




public sealed class GetStoryDetailHandler
    : IRequestHandler<GetStoryDetailQuery, StoryDetailResult>
{
    private readonly IStoryRepository _storyRepository;
    private readonly ICurrentUserService _currentUser;

    public GetStoryDetailHandler(
        IStoryRepository storyRepository,
        ICurrentUserService currentUser)
    {
        _storyRepository = storyRepository;
        _currentUser = currentUser;
    }

    public async Task<StoryDetailResult> Handle(
        GetStoryDetailQuery request,
        CancellationToken cancellationToken)
    {
        var viewerId = _currentUser.UserId;

        
        
        
        var story = await _storyRepository.GetStoryDetailAsync(
            request.StoryId,
            viewerId,
            cancellationToken
        );

        
        
        return new StoryDetailResult(
            story.Id,
            story.UserId,
            story.UserName,
            story.AvatarUrl,
            story.MediaUrl,
            story.MediaType,
            story.IsViewed,
            story.CreatedAt,
            story.ExpiresAt
        );
    }
}
