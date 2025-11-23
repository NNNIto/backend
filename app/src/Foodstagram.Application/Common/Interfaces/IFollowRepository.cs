// src/Foodstagram.Application/Common/Interfaces/IFollowRepository.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;

/// <summary>
/// フォロー / フォロワー関係を扱うリポジトリ。
/// </summary>
public interface IFollowRepository
{
    /// <summary>
    /// 自分をフォローしているユーザー一覧を取得。
    /// </summary>
    Task<IReadOnlyList<UserSummaryModel>> GetFollowersAsync(
        long userId,
        CancellationToken cancellationToken);

    /// <summary>
    /// 自分がフォローしているユーザー一覧を取得。
    /// </summary>
    Task<IReadOnlyList<UserSummaryModel>> GetFollowingAsync(
        long userId,
        CancellationToken cancellationToken);
}
