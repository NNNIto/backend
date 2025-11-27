
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Profiles.GetCurrentProfile;
using Foodstagram.Application.Profiles.GetMyPosts;

namespace Foodstagram.Application.Common.Interfaces;




public interface IUserRepository
{
	
	
	
	Task<ProfileHeaderModel> GetProfileHeaderAsync(
		long userId,
		CancellationToken cancellationToken);

	
	
	
	Task<IReadOnlyList<MyPostModel>> GetMyPostsAsync(
		long userId,
		CancellationToken cancellationToken);

	
	
	
	Task UpdateProfileAsync(
		long userId,
		string displayName,
		string bio,
		string avatarUrl,
		CancellationToken cancellationToken);
}
