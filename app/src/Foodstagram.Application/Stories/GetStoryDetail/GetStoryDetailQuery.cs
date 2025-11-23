// src/Foodstagram.Application/Stories/GetStoryDetail/GetStoryDetailQuery.cs
using MediatR;

namespace Foodstagram.Application.Stories.GetStoryDetail;

/// <summary>
/// 特定のストーリー詳細を取得するクエリ。
/// </summary>
public sealed record GetStoryDetailQuery(long StoryId)
    : IRequest<StoryDetailResult>;
