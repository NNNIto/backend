using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Common.Models;
using Foodstagram.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Foodstagram.Infrastructure.Repositories;

public sealed class ShareRepository : IShareRepository
{
    private readonly FoodstagramDbContext _db;

    public ShareRepository(FoodstagramDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<UserSummaryModel>> GetShareSuggestionsAsync(long userId, CancellationToken cancellationToken)
    {
        var followedIds = await _db.Follows
            .Where(f => f.FollowerId == userId)
            .Select(f => f.FolloweeId)
            .ToListAsync(cancellationToken);

        return await _db.Users
            .Where(u => u.Id != userId && !followedIds.Contains(u.Id))
            .OrderByDescending(u => u.CreatedAt)
            .Take(20)
            .Select(u => new UserSummaryModel(u.Id, u.UserName, u.DisplayName, u.AvatarUrl))
            .ToListAsync(cancellationToken);
    }
}
