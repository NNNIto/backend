// src/Foodstagram.Application/Common/Models/UserSummaryModel.cs
namespace Foodstagram.Application.Common.Models;

/// <summary>
/// フォロー一覧 / フォロワー一覧 / 共有候補 などで使う
/// 「軽量なユーザー情報」モデル。
/// </summary>
public sealed record UserSummaryModel(
    long UserId,
    string UserName,
    string DisplayName,
    string AvatarUrl
);
