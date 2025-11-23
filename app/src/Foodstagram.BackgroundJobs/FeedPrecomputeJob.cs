using Foodstagram.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Foodstagram.BackgroundJobs;

/// <summary>
/// ホームフィードのキャッシュやランキングスコアなどを事前計算して
/// フィードレスポンスを高速化するためのジョブ。
/// （例）
/// - 投稿のスコア計算（Like数、コメント数）
/// - トレンド投稿の事前取得
/// - Redis にキャッシュ保存
/// </summary>
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

    /// <summary>
    /// バッチのメイン処理
    /// </summary>
    public async Task ExecuteAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("FeedPrecomputeJob started at {Time}", DateTimeOffset.UtcNow);

        // ――― Step1: 人気投稿の上位N件（例: Like + Comment の多い順） ―――
        var topPosts = await _db.Posts
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .OrderByDescending(p => p.Likes.Count + p.Comments.Count)
            .Take(50)
            .ToListAsync(ct);

        // ――― Step2: キャッシュ保存処理（本番は Redis / Memory Cache 等） ―――
        // ここではサンプルとしてログ出力のみ
        _logger.LogInformation("Top posts precomputed. Count={Count}", topPosts.Count);

        _logger.LogInformation("FeedPrecomputeJob finished at {Time}", DateTimeOffset.UtcNow);
    }
}
