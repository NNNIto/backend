using Foodstagram.Domain.Common;

namespace Foodstagram.Domain.Activities;

public sealed class Activity : EntityBase
{
    private Activity() { }

    public Activity(
        ActivityType type,
        long fromUserId,
        long toUserId,
        long? postId = null)
    {
        Type = type;
        FromUserId = fromUserId;
        ToUserId = toUserId;
        PostId = postId;
    }

    public ActivityType Type { get; private set; }

    
    public long FromUserId { get; private set; }

    
    public long ToUserId { get; private set; }

    
    public long? PostId { get; private set; }
}

public enum ActivityType
{
    Like = 1,
    Comment = 2,
    Follow = 3
}
