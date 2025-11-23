using Foodstagram.Domain.Common;

namespace Foodstagram.Domain.Stories;

public sealed class Story : AggregateRoot
{
    private readonly List<StoryView> _views = new();

    private Story() { }

    public Story(long userId, string imageUrl, DateTimeOffset createdAt, TimeSpan lifetime)
    {
        UserId = userId;
        ImageUrl = imageUrl;
        CreatedAt = createdAt;
        ExpiresAt = createdAt.Add(lifetime);
    }

    public long UserId { get; private set; }
    public string ImageUrl { get; private set; } = string.Empty;

    public DateTimeOffset ExpiresAt { get; private set; }

    public IReadOnlyCollection<StoryView> Views => _views.AsReadOnly();

    public bool IsExpired(DateTimeOffset now) => now >= ExpiresAt;

    public bool HasViewed(long viewerUserId)
        => _views.Any(v => v.ViewerUserId == viewerUserId);

    public void AddView(long viewerUserId, DateTimeOffset viewedAt)
    {
        if (IsExpired(viewedAt)) return;

        if (HasViewed(viewerUserId)) return;

        var view = new StoryView(Id, viewerUserId, viewedAt);
        _views.Add(view);
        Touch();
    }
}
