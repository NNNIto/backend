// src/Foodstagram.Application/Common/Interfaces/IShareRepository.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;

/// <summary>
/// 投稿の「共有候補ユーザー」などを扱うリポジトリ。
/// </summary>
public interface IShareRepository
{
    /// <summary>
    /// 投稿を共有するときに候補として出すユーザー一覧を取得。
    /// </summary>
    Task<IReadOnlyList<UserSummaryModel>> GetShareSuggestionsAsync(
        long userId,
        CancellationToken cancellationToken);
}
