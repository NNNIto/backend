
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;





public interface IActivityRepository
{
    
    
    
    Task<IReadOnlyList<ActivityModel>> GetActivitiesAsync(
        long userId,
        CancellationToken cancellationToken);
}
