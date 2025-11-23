// src/Foodstagram.Application/Common/Interfaces/IPostRepository.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Models;

namespace Foodstagram.Application.Common.Interfaces;

/// <summary>
/// 投稿（Post）を扱うリポジトリのインターフェース。
/// ホームフィードやいいねトグルなど、投稿まわりの取得・更新を担当。
/// </summary>
public interface IPostRepository
{
    /// <summary>
    /// ホームフィード用の投稿一覧を取得する。
    /// </summary>
    /// <param name="userId">ログインユーザーID（推薦・並び順に利用する想定）</param>
    /// <param name="page">ページ番号（1始まり）</param>
    /// <param name="pageSize">1ページあたり件数</param>
    /// <returns>投稿一覧と総件数</returns>
    Task<(IReadOnlyList<PostSummaryModel> Items, int TotalCount)> GetFeedAsync(
        long userId,
        int page,
        int pageSize,
        CancellationToken cancellationToken);

    /// <summary>
    /// いいねの ON/OFF をトグルする。
    /// </summary>
    Task ToggleLikeAsync(
        long postId,
        long userId,
        CancellationToken cancellationToken);
}
