using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Activities.GetActivities;

namespace Foodstagram.Application.Common.Interfaces;

public interface IActivityRepository
{
    Task<IReadOnlyList<ActivityItemModel>> GetActivitiesAsync(
        long userId,
        CancellationToken cancellationToken);
}
