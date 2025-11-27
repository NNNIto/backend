
using System;

namespace Foodstagram.Application.Common.Models;





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
