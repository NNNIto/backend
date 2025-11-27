using Foodstagram.Domain.Common;

namespace Foodstagram.Domain.Follows;

public sealed class Follow : EntityBase
{
    private Follow() { }

    private Follow(long followerId, long followeeId)
    {
        if (followerId == followeeId)
        {
            throw new ArgumentException("User cannot follow themselves.");
        }

        FollowerId = followerId;
        FolloweeId = followeeId;
    }

    
    public long FollowerId { get; private set; }

    
    public long FolloweeId { get; private set; }

    public static Follow Create(long followerId, long followeeId)
        => new(followerId, followeeId);
}
