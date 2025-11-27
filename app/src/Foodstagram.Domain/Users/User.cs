using Foodstagram.Domain.Common;
using Foodstagram.Domain.Follows;
using Foodstagram.Domain.Posts;

namespace Foodstagram.Domain.Users;

public sealed class User : AggregateRoot
{
    private readonly List<Post> _posts = new();
    private readonly List<Follow> _followers = new();
    private readonly List<Follow> _followings = new();

    private User() { }

    public User(string userName, string displayName, string? bio = null, string? avatarUrl = null)
    {
        UserName = userName;
        DisplayName = displayName;
        Bio = bio;
        AvatarUrl = avatarUrl;
    }

    public string UserName { get; private set; } = string.Empty;
    public string DisplayName { get; private set; } = string.Empty;
    public string? Bio { get; private set; }
    public string? AvatarUrl { get; private set; }

    public IReadOnlyCollection<Post> Posts => _posts.AsReadOnly();
    public IReadOnlyCollection<Follow> Followers => _followers.AsReadOnly();
    public IReadOnlyCollection<Follow> Followings => _followings.AsReadOnly();

    public void UpdateProfile(string displayName, string? bio, string? avatarUrl)
    {
        DisplayName = displayName;
        Bio = bio;
        AvatarUrl = avatarUrl;
        Touch();
    }

    
    internal void AddPost(Post post)
    {
        _posts.Add(post);
    }

    internal void AddFollower(Follow follow)
    {
        _followers.Add(follow);
    }

    internal void AddFollowing(Follow follow)
    {
        _followings.Add(follow);
    }
}
