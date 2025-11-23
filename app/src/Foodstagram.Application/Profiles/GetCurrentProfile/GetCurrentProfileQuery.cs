// src/Foodstagram.Application/Profiles/GetCurrentProfile/GetCurrentProfileQuery.cs
using MediatR;

namespace Foodstagram.Application.Profiles.GetCurrentProfile;

/// <summary>
/// ログインユーザーのプロフィールヘッダーを取得するクエリ。
/// </summary>
public sealed record GetCurrentProfileQuery()
    : IRequest<ProfileHeaderModel>;
