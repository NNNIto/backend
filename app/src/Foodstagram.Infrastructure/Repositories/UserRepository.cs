using Foodstagram.Application.Common.Interfaces;
using Foodstagram.Application.Profiles.GetCurrentProfile;
using Foodstagram.Application.Profiles.GetMyPosts;
using Foodstagram.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Foodstagram.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
	private readonly FoodstagramDbContext _db;

	public UserRepository(FoodstagramDbContext db)
	{
		_db = db;
	}

	public async Task<ProfileHeaderModel> GetProfileHeaderAsync(long userId, CancellationToken ct)
	{
		var user = await _db.Users.FindAsync(new object[] { userId }, ct);

		var postCount = await _db.Posts.CountAsync(p => p.AuthorId == userId, ct);
		var followerCount = await _db.Follows.CountAsync(f => f.FolloweeId == userId, ct);
		var followingCount = await _db.Follows.CountAsync(f => f.FollowerId == userId, ct);

		return new ProfileHeaderModel(
			user!.Id,
			user.UserName,
			user.DisplayName,
			user.Bio ?? "",
			user.AvatarUrl ?? "",
			postCount,
			followerCount,
			followingCount
		);
	}

	public async Task<IReadOnlyList<MyPostModel>> GetMyPostsAsync(long userId, CancellationToken ct)
	{
		return await _db.Posts
			.Where(p => p.AuthorId == userId)
			.OrderByDescending(p => p.CreatedAt)
			.Select(p => new MyPostModel(
				p.Id,
				p.ImageUrl,
				p.Likes.Count,
				p.Comments.Count
			))
			.ToListAsync(ct);
	}

	public async Task UpdateProfileAsync(long userId, string displayName, string? bio, string? avatarUrl, CancellationToken ct)
	{
		var user = await _db.Users.FirstAsync(u => u.Id == userId, ct);

		user.UpdateProfile(displayName, bio, avatarUrl);

		await _db.SaveChangesAsync(ct);
	}
}
