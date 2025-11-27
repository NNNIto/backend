
using System;

namespace Foodstagram.Application.Stories.GetStoryDetail;




public sealed record StoryDetailResult(
	long Id,
	long UserId,
	string UserName,
	string AvatarUrl,
	string MediaUrl,
	string MediaType,          
	bool IsViewed,
	DateTimeOffset CreatedAt,
	DateTimeOffset ExpiresAt
);
