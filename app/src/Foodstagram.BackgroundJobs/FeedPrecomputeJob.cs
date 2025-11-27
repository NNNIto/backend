using Foodstagram.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foodstagram.BackgroundJobs;









public sealed class FeedPrecomputeJob
{
    private readonly FoodstagramDbContext _db;
    private readonly ILogger<FeedPrecomputeJob> _logger;

    public FeedPrecomputeJob(
        FoodstagramDbContext db,
        ILogger<FeedPrecomputeJob> logger)
    {
        _db = db;
        _logger = logger;
    }

    
    
    
    public async Task ExecuteAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("FeedPrecomputeJob started at {Time}", DateTimeOffset.UtcNow);

        
        var topPosts = await _db.Posts
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .OrderByDescending(p => p.Likes.Count + p.Comments.Count)
            .Take(50)
            .ToListAsync(ct);

        
        
        _logger.LogInformation("Top posts precomputed. Count={Count}", topPosts.Count);

        _logger.LogInformation("FeedPrecomputeJob finished at {Time}", DateTimeOffset.UtcNow);
    }
}
