// src/Foodstagram.Application/Common/Models/ActivityModel.cs
using System;

namespace Foodstagram.Application.Common.Models;

/// <summary>
/// 「誰が」「いつ」「何をした」を表すアクティビティ（通知）モデル。
/// UI 側の ActivityItemDto にマッピングされる想定。
/// </summary>
public sealed record ActivityModel(
    long Id,
    string Type,                // "like", "follow", "comment" など
    long FromUserId,
    string FromUserName,
    string FromUserAvatarUrl,
    long? PostId,
    DateTimeOffset CreatedAt
);
