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
}
