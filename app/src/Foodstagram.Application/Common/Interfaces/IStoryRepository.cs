
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;




public interface IStoryRepository
{
    
    
    
    
    Task<IReadOnlyList<StorySummaryModel>> GetStoriesAsync(
        long userId,
        CancellationToken cancellationToken);

        Task<StoryDetailModel> GetStoryDetailAsync(
            long storyId,
            long viewerUserId,
            CancellationToken cancellationToken);
}
