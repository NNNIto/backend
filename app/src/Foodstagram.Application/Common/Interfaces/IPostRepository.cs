using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;

public interface IPostRepository
{
    Task<(IReadOnlyList<PostSummaryModel> Items, int TotalCount)> GetFeedAsync(
        long userId,
        int page,
        int pageSize,
        CancellationToken cancellationToken);

    Task<PostDetailModel> GetPostDetailAsync(
        long postId,
        long userId,
        CancellationToken cancellationToken);

    Task ToggleLikeAsync(
        long postId,
        long userId,
        CancellationToken cancellationToken);
}
