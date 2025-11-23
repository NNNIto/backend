// src/Foodstagram.Application/Common/Interfaces/IActivityRepository.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;

/// <summary>
/// アクティビティ（通知）を扱うリポジトリ。
/// 例: いいねされた、フォローされた、コメントされた など。
/// </summary>
public interface IActivityRepository
{
    /// <summary>
    /// ログインユーザー向けのアクティビティ一覧を取得。
    /// </summary>
    Task<IReadOnlyList<ActivityModel>> GetActivitiesAsync(
        long userId,
        CancellationToken cancellationToken);
}
