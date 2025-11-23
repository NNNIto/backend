using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Activities.GetActivities;
using Foodstagram.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Foodstagram.Infrastructure.Repositories;

public sealed class ActivityRepository : IActivityRepository
{
    private readonly FoodstagramDbContext _db;

    public ActivityRepository(FoodstagramDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<ActivityItemModel>> GetActivitiesAsync(long userId, CancellationToken ct)
    {
        return await _db.Activities
            .Where(a => a.ToUserId == userId)
            .OrderByDescending(a => a.CreatedAt)
            .Select(a => new ActivityItemModel(
                a.Id,
                a.Type.ToString(),
                a.FromUserId,
                "",
                "",
                a.PostId,
                a.CreatedAt
            ))
            .ToListAsync(ct);
    }
}
