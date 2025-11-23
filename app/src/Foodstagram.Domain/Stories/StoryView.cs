using Foodstagram.Domain.Common;

namespace Foodstagram.Domain.Stories;

public sealed class StoryView : EntityBase
{
    private StoryView() { }

    public StoryView(long storyId, long viewerUserId, DateTimeOffset viewedAt)
    {
        StoryId = storyId;
        ViewerUserId = viewerUserId;
        ViewedAt = viewedAt;
    }

    public long StoryId { get; private set; }
    public long ViewerUserId { get; private set; }
    public DateTimeOffset ViewedAt { get; private set; }
}
