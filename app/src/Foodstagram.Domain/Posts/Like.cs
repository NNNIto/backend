using Foodstagram.Domain.Common;

namespace Foodstagram.Domain.Posts;

public sealed class Like : EntityBase
{
    private Like() { }

    public Like(long postId, long userId)
    {
        PostId = postId;
        UserId = userId;
    }

    public long PostId { get; private set; }
    public long UserId { get; private set; }
}
