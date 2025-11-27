using System;
using System.Collections.Generic;

namespace Foodstagram.Application.Common.Models;

public sealed record CommentModel(
    long Id,
    long UserId,
    string UserName,
    string Text,
    DateTimeOffset CreatedAt
);

public sealed record PostDetailModel(
    long Id,
    long AuthorId,
    string AuthorName,
    string AuthorAvatarUrl,
    string ImageUrl,
    string Caption,
    int LikeCount,
    int CommentCount,
    bool IsLiked,
    DateTimeOffset CreatedAt,
    IReadOnlyList<CommentModel> Comments
);
