// src/Foodstagram.Application/Stories/GetStoryDetail/GetStoryDetailHandler.cs
using System.Threading;
using System.Threading.Tasks;
using Foodstagram.Application.Common.Interfaces;
using MediatR;

namespace Foodstagram.Application.Stories.GetStoryDetail;

/// <summary>
/// ストーリー詳細取得のハンドラ。
/// </summary>
public sealed class GetStoryDetailHandler
    : IRequestHandler<GetStoryDetailQuery, StoryDetailResult>
{
    private readonly IStoryRepository _storyRepository;
    private readonly ICurrentUserService _currentUser;

    public GetStoryDetailHandler(
        IStoryRepository storyRepository,
        ICurrentUserService currentUser)
    {
        _storyRepository = storyRepository;
        _currentUser = currentUser;
    }

    public async Task<StoryDetailResult> Handle(
        GetStoryDetailQuery request,
        CancellationToken cancellationToken)
    {
        var viewerId = _currentUser.UserId;

        // 実装イメージ：
        // - DB からストーリーを取得
        // - （必要なら）閲覧履歴の更新も Repository 側で実施
        var story = await _storyRepository.GetStoryDetailAsync(
            request.StoryId,
            viewerId,
            cancellationToken
        );

        // Repository 側で StoryDetailResult をそのまま返す設計でも良いですが、
        // ここでは「Application の結果オブジェクト StoryDetailResult に詰め直す」イメージ。
        return new StoryDetailResult(
            story.Id,
            story.UserId,
            story.UserName,
            story.AvatarUrl,
            story.MediaUrl,
            story.MediaType,
            story.IsViewed,
            story.CreatedAt,
            story.ExpiresAt
        );
    }
}
