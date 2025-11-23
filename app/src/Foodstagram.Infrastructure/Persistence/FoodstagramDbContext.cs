using Foodstagram.Domain.Users;
using Foodstagram.Domain.Posts;
using Foodstagram.Domain.Stories;
using Foodstagram.Domain.Follows;
using Foodstagram.Domain.Activities;
using Microsoft.EntityFrameworkCore;

namespace Foodstagram.Infrastructure.Persistence;

public sealed class FoodstagramDbContext : DbContext
{
    public FoodstagramDbContext(DbContextOptions<FoodstagramDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Story> Stories => Set<Story>();
    public DbSet<StoryView> StoryViews => Set<StoryView>();
    public DbSet<Follow> Follows => Set<Follow>();
    public DbSet<Activity> Activities => Set<Activity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(FoodstagramDbContext).Assembly);
    }
}
