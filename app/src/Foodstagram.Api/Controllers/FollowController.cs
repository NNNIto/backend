// src/Foodstagram.Api/Controllers/FollowController.cs
using Foodstagram.Api.Dtos.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Foodstagram.Application.Follows.GetFollowers;
// using Foodstagram.Application.Follows.GetFollowing;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FollowController : ControllerBase
{
    private readonly IMediator _mediator;

    public FollowController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// フォロワー一覧
    /// </summary>
    [HttpGet("followers")]
    public async Task<ActionResult<IEnumerable<UserSummaryDto>>> GetFollowersAsync(
        CancellationToken cancellationToken = default)
    {
        // TODO
        return Ok(Array.Empty<UserSummaryDto>());
    }

    /// <summary>
    /// フォロー一覧
    /// </summary>
    [HttpGet("following")]
    public async Task<ActionResult<IEnumerable<UserSummaryDto>>> GetFollowingAsync(
        CancellationToken cancellationToken = default)
    {
        // TODO
        return Ok(Array.Empty<UserSummaryDto>());
    }
}
