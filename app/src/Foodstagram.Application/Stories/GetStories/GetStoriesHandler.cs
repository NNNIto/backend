
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Common.Models;
using MediatR;

namespace Foodstagram.Application.Stories.GetStories;




public sealed class GetStoriesHandler
    : IRequestHandler<GetStoriesQuery, IReadOnlyList<StorySummaryModel>>
{
    private readonly IStoryRepository _storyRepository;
    private readonly ICurrentUserService _currentUser;

    public GetStoriesHandler(
        IStoryRepository storyRepository,
        ICurrentUserService currentUser)
    {
        _storyRepository = storyRepository;
        _currentUser = currentUser;
    }

    public async Task<IReadOnlyList<StorySummaryModel>> Handle(
        GetStoriesQuery request,
        CancellationToken cancellationToken)
    {
        
        var userId = _currentUser.UserId;

        var stories = await _storyRepository.GetStoriesAsync(
            userId,
            cancellationToken
        );

        return stories;
    }
}
