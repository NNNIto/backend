// src/Foodstagram.Application/Common/Models/PostSummaryModel.cs
using System;

namespace Foodstagram.Application.Common.Models;

/// <summary>
/// ホームフィードや一覧画面で使う「投稿サマリ」モデル。
/// Domain の Post エンティティよりも、UI 向けに整えた軽量版。
/// </summary>
public sealed record PostSummaryModel(
    long Id,
    long AuthorId,
    string AuthorName,
    string AuthorAvatarUrl,
    string ImageUrl,
    string Caption,
    int LikeCount,
    int CommentCount,
    bool IsLiked,
    DateTimeOffset CreatedAt
);
