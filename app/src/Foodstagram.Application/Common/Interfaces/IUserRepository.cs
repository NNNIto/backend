// src/Foodstagram.Application/Common/Interfaces/IUserRepository.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Profiles.GetCurrentProfile;
using Foodstagram.Application.Profiles.GetMyPosts;

namespace Foodstagram.Application.Common.Interfaces;

/// <summary>
/// ユーザー（User）/ プロフィールまわりを扱うリポジトリ。
/// </summary>
public interface IUserRepository
{
	/// <summary>
	/// ログインユーザーのプロフィールヘッダー情報を取得。
	/// </summary>
	Task<ProfileHeaderModel> GetProfileHeaderAsync(
		long userId,
		CancellationToken cancellationToken);

	/// <summary>
	/// 自分の投稿グリッド（プロフィール画面用）を取得。
	/// </summary>
	Task<IReadOnlyList<MyPostModel>> GetMyPostsAsync(
		long userId,
		CancellationToken cancellationToken);

	/// <summary>
	/// プロフィール情報を更新。
	/// </summary>
	Task UpdateProfileAsync(
		long userId,
		string displayName,
		string bio,
		string avatarUrl,
		CancellationToken cancellationToken);
}
