using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Common.Models;
using Foodstagram.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Foodstagram.Infrastructure.Repositories;

public sealed class FollowRepository : IFollowRepository
{
    private readonly FoodstagramDbContext _db;

    public FollowRepository(FoodstagramDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<UserSummaryModel>> GetFollowersAsync(long userId, CancellationToken cancellationToken)
    {
        var followerIds = await _db.Follows
            .Where(f => f.FolloweeId == userId)
            .Select(f => f.FollowerId)
            .ToListAsync(cancellationToken);

        return await _db.Users
            .Where(u => followerIds.Contains(u.Id))
            .Select(u => new UserSummaryModel(u.Id, u.UserName, u.DisplayName, u.AvatarUrl))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<UserSummaryModel>> GetFollowingAsync(long userId, CancellationToken cancellationToken)
    {
        var followeeIds = await _db.Follows
            .Where(f => f.FollowerId == userId)
            .Select(f => f.FolloweeId)
            .ToListAsync(cancellationToken);

        return await _db.Users
            .Where(u => followeeIds.Contains(u.Id))
            .Select(u => new UserSummaryModel(u.Id, u.UserName, u.DisplayName, u.AvatarUrl))
            .ToListAsync(cancellationToken);
    }
}
