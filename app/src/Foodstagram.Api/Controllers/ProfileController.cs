// src/Foodstagram.Api/Controllers/ProfileController.cs
using Foodstagram.Api.Dtos.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Foodstagram.Application.Profiles.GetCurrentProfile;
// using Foodstagram.Application.Profiles.GetMyPosts;
// using Foodstagram.Application.Profiles.UpdateProfile;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// ログインユーザーのプロフィールヘッダーを取得
    /// </summary>
    [HttpGet("me")]
    public async Task<ActionResult<ProfileHeaderDto>> GetCurrentAsync(
        CancellationToken cancellationToken = default)
    {
        // TODO: GetCurrentProfileQuery を呼ぶ
        return Ok(new ProfileHeaderDto
        {
            UserId = 1,
            UserName = "demo",
            DisplayName = "Demo User",
            Bio = "",
            PostCount = 0,
            FollowerCount = 0,
            FollowingCount = 0,
            AvatarUrl = ""
        });
    }

    /// <summary>
    /// 自分の投稿一覧
    /// </summary>
    [HttpGet("me/posts")]
    public async Task<ActionResult<IEnumerable<ProfilePostDto>>> GetMyPostsAsync(
        CancellationToken cancellationToken = default)
    {
        // TODO: GetMyPostsQuery
        return Ok(Array.Empty<ProfilePostDto>());
    }

    /// <summary>
    /// プロフィール更新
    /// </summary>
    [HttpPut("me")]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateProfileRequestDto request,
        CancellationToken cancellationToken = default)
    {
        // TODO: UpdateProfileCommand
        return NoContent();
    }
}
