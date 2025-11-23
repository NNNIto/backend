// src/Foodstagram.Application/Common/Interfaces/IStoryRepository.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;

/// <summary>
/// ストーリー（Story）を扱うリポジトリのインターフェース。
/// </summary>
public interface IStoryRepository
{
    /// <summary>
    /// ホーム画面上部のストーリー一覧を取得する。
    /// </summary>
    /// <param name="userId">ログインユーザーID（未読判定などに利用）</param>
    Task<IReadOnlyList<StorySummaryModel>> GetStoriesAsync(
        long userId,
        CancellationToken cancellationToken);
}
