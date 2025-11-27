
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;




public interface IFollowRepository
{
    
    
    
    Task<IReadOnlyList<UserSummaryModel>> GetFollowersAsync(
        long userId,
        CancellationToken cancellationToken);

    
    
    
    Task<IReadOnlyList<UserSummaryModel>> GetFollowingAsync(
        long userId,
        CancellationToken cancellationToken);
}
