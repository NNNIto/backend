// src/Foodstagram.Application/Stories/GetStoryDetail/StoryDetailResult.cs
using System;

namespace Foodstagram.Application.Stories.GetStoryDetail;

/// <summary>
/// ストーリー詳細画面に必要な情報。
/// </summary>
public sealed record StoryDetailResult(
	long Id,
	long UserId,
	string UserName,
	string AvatarUrl,
	string MediaUrl,
	string MediaType,          // "image", "video" など
	bool IsViewed,
	DateTimeOffset CreatedAt,
	DateTimeOffset ExpiresAt
);
