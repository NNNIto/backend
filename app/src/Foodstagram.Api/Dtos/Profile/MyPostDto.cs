namespace Foodstagram.Api.Dtos.Profile;

public sealed class MyPostDto
{
    public long Id { get; init; }
    public string ThumbnailUrl { get; init; } = string.Empty;
    public int LikeCount { get; init; }
    public int CommentCount { get; init; }
}
