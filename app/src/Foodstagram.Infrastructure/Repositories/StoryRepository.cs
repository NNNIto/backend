using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Common.Models;
using Foodstagram.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Foodstagram.Infrastructure.Repositories;

public sealed class StoryRepository : IStoryRepository
{
    private readonly FoodstagramDbContext _db;

    public StoryRepository(FoodstagramDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<StorySummaryModel>> GetStoriesAsync(long userId, CancellationToken ct)
    {
        return await _db.Stories
            .Include(s => s.Views)
            .OrderByDescending(s => s.CreatedAt)
            .Select(s => new StorySummaryModel(
                s.Id,
                s.UserId,
                "",
                "",
                s.Views.Any(v => v.ViewerUserId == userId)
            ))
            .ToListAsync(ct);
    }

    public async Task<StoryDetailModel> GetStoryDetailAsync(long storyId, long viewerUserId, CancellationToken cancellationToken)
    {
        var q = await _db.Stories
            .Where(s => s.Id == storyId)
            .Include(s => s.Views)
            .Join(_db.Users, s => s.UserId, u => u.Id, (s, u) => new { s, u })
            .Select(x => new StoryDetailModel(
                x.s.Id,
                x.s.UserId,
                x.u.UserName,
                x.u.AvatarUrl ?? string.Empty,
                x.s.ImageUrl ?? string.Empty,
                /* MediaType */ string.Empty,
                x.s.Views.Any(v => v.ViewerUserId == viewerUserId),
                x.s.CreatedAt,
                x.s.ExpiresAt
            ))
            .FirstOrDefaultAsync(cancellationToken);

        return q!;
    }
}
