namespace Foodstagram.Domain.Common;

public abstract class EntityBase
{
    public long Id { get; protected set; }

    public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; protected set; }

    protected void Touch()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
