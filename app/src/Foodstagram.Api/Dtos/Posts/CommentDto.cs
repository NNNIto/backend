namespace Foodstagram.Api.Dtos.Posts;

public sealed class CommentDto
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public DateTimeOffset CreatedAt { get; init; }
}
