using Foodstagram.Domain.Common;
using Foodstagram.Domain.Users;

namespace Foodstagram.Domain.Posts;

public sealed class Post : AggregateRoot
{
    private readonly List<Like> _likes = new();
    private readonly List<Comment> _comments = new();

    private Post() { }

    public Post(long authorId, string imageUrl, string? caption = null)
    {
        AuthorId = authorId;
        ImageUrl = imageUrl;
        Caption = caption ?? string.Empty;
    }

    public long AuthorId { get; private set; }
    public string ImageUrl { get; private set; } = string.Empty;
    public string Caption { get; private set; } = string.Empty;

    public IReadOnlyCollection<Like> Likes => _likes.AsReadOnly();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    public int LikeCount => _likes.Count;
    public int CommentCount => _comments.Count;

    public void UpdateCaption(string caption)
    {
        Caption = caption;
        Touch();
    }

    public bool IsLikedBy(long userId) => _likes.Any(l => l.UserId == userId);

    public void ToggleLike(long userId)
    {
        if (IsLikedBy(userId))
        {
            RemoveLike(userId);
        }
        else
        {
            AddLike(userId);
        }
    }

    public void AddLike(long userId)
    {
        if (IsLikedBy(userId))
        {
            return;
        }

        var like = new Like(Id, userId);
        _likes.Add(like);
        Touch();
    }

    public void RemoveLike(long userId)
    {
        var like = _likes.FirstOrDefault(l => l.UserId == userId);
        if (like is null) return;

        _likes.Remove(like);
        Touch();
    }

    public Comment AddComment(long userId, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Comment text cannot be empty.", nameof(text));
        }

        var comment = new Comment(Id, userId, text);
        _comments.Add(comment);
        Touch();
        return comment;
    }
}
