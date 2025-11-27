using Foodstagram.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foodstagram.BackgroundJobs;





public sealed class StoryCleanupJob
{
    private readonly FoodstagramDbContext _db;
    private readonly ILogger<StoryCleanupJob> _logger;

    public StoryCleanupJob(
        FoodstagramDbContext db,
        ILogger<StoryCleanupJob> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task ExecuteAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("StoryCleanupJob started at {Time}", DateTimeOffset.UtcNow);

        var now = DateTimeOffset.UtcNow;

        
        var expiredStories = await _db.Stories
            .Where(s => s.ExpiresAt <= now)
            .ToListAsync(ct);

        if (expiredStories.Count > 0)
        {
            
            _db.Stories.RemoveRange(expiredStories);
            await _db.SaveChangesAsync(ct);

            _logger.LogInformation("Deleted expired stories: {Count}", expiredStories.Count);
        }
        else
        {
            _logger.LogInformation("No expired stories found.");
        }

        _logger.LogInformation("StoryCleanupJob finished at {Time}", DateTimeOffset.UtcNow);
    }
}
