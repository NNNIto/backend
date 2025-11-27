
using System;

namespace Foodstagram.Application.Common.Models;





public sealed record ActivityModel(
    long Id,
    string Type,                
    long FromUserId,
    string FromUserName,
    string FromUserAvatarUrl,
    long? PostId,
    DateTimeOffset CreatedAt
);
