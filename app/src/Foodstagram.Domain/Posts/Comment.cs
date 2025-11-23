using Foodstagram.Domain.Common;

namespace Foodstagram.Domain.Posts;

public sealed class Comment : EntityBase
{
    private Comment() { }

    public Comment(long postId, long userId, string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Comment text cannot be empty.", nameof(text));
        }

        PostId = postId;
        UserId = userId;
        Text = text;
    }

    public long PostId { get; private set; }
    public long UserId { get; private set; }
    public string Text { get; private set; } = string.Empty;

    public void UpdateText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Comment text cannot be empty.", nameof(text));
        }

        Text = text;
        Touch();
    }
}
