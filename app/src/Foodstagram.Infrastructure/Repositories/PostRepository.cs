using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Common.Models;
using Foodstagram.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Foodstagram.Infrastructure.Persistence;

namespace Foodstagram.Infrastructure.Repositories;

public sealed class PostRepository : IPostRepository
{
    private readonly FoodstagramDbContext _db;

    public PostRepository(FoodstagramDbContext db)
    {
        _db = db;
    }

    public async Task<(IReadOnlyList<PostSummaryModel> Items, int TotalCount)>
        GetFeedAsync(long userId, int page, int pageSize, CancellationToken ct)
    {
        var query = _db.Posts
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .OrderByDescending(p => p.CreatedAt);

        var total = await query.CountAsync(ct);

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new PostSummaryModel(
                p.Id,
                p.AuthorId,
                "", 
                "", 
                p.ImageUrl,
                p.Caption,
                p.Likes.Count,
                p.Comments.Count,
                p.Likes.Any(l => l.UserId == userId),
                p.CreatedAt
            ))
            .ToListAsync(ct);

        return (items, total);
    }

    public async Task<PostDetailModel> GetPostDetailAsync(long postId, long currentUserId, CancellationToken ct)
    {
        var post = await _db.Posts
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .FirstAsync(p => p.Id == postId, ct);

        return new PostDetailModel(
            post.Id,
            post.AuthorId,
            "",
            "",
            post.ImageUrl,
            post.Caption,
            post.Likes.Count,
            post.Comments.Count,
            post.Likes.Any(l => l.UserId == currentUserId),
            post.CreatedAt,
            post.Comments.Select(c =>
                new CommentModel(c.Id, c.UserId, "", c.Text, c.CreatedAt)).ToList()
        );
    }

    public async Task ToggleLikeAsync(long postId, long userId, CancellationToken ct)
    {
        var like = await _db.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId, ct);

        if (like is null)
        {
            _db.Likes.Add(new Like(postId, userId));
        }
        else
        {
            _db.Likes.Remove(like);
        }

        await _db.SaveChangesAsync(ct);
    }
}
