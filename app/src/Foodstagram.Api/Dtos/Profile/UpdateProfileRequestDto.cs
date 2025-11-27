// src/Foodstagram.Api/Dtos/Profile/UpdateProfileRequestDto.cs
namespace Foodstagram.Api.Dtos.Profile;

public sealed class UpdateProfileRequestDto
{
    /// <summary>表示名</summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>自己紹介文</summary>
    public string Bio { get; set; } = string.Empty;

    /// <summary>Web サイトURL</summary>
    public string WebsiteUrl { get; set; } = string.Empty;

    /// <summary>アイコン画像URL</summary>
    public string AvatarUrl { get; set; } = string.Empty;
}
