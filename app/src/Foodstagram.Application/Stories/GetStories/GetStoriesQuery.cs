// src/Foodstagram.Application/Stories/GetStories/GetStoriesQuery.cs
using System.Collections.Generic;
using Foodstagram.Application.Common.Models;
using MediatR;

namespace Foodstagram.Application.Stories.GetStories;

/// <summary>
/// ホーム画面上部のストーリー一覧を取得するクエリ。
/// </summary>
public sealed record GetStoriesQuery()
    : IRequest<IReadOnlyList<StorySummaryModel>>;
