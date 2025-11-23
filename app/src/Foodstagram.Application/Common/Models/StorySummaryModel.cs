// src/Foodstagram.Application/Common/Models/StorySummaryModel.cs
namespace Foodstagram.Application.Common.Models;

/// <summary>
/// ホーム画面上部のストーリー一覧で使うストーリーサマリ。
/// 「誰のストーリーが未読か」がわかればよい、軽量モデル。
/// </summary>
public sealed record StorySummaryModel(
    long Id,
    long UserId,
    string UserName,
    string AvatarUrl,
    bool IsViewed
);
