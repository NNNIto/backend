namespace Foodstagram.Api.Dtos.Profile;

public class ProfilePostDto
{
    public long Id { get; set; }

    // 投稿のメイン画像URL
    public string ImageUrl { get; set; } = string.Empty;

    // キャプション（本文）
    public string Caption { get; set; } = string.Empty;

    // いいね数
    public int LikeCount { get; set; }

    // コメント数
    public int CommentCount { get; set; }

    // 投稿日時
    public DateTime CreatedAt { get; set; }
}
