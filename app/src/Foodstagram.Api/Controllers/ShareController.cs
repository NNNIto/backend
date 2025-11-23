// src/Foodstagram.Api/Controllers/ShareController.cs
using Foodstagram.Api.Dtos.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Foodstagram.Application.Shares.GetShareSuggestions;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShareController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShareController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// 共有候補ユーザー一覧
    /// </summary>
    [HttpGet("suggestions")]
    public async Task<ActionResult<IEnumerable<UserSummaryDto>>> GetSuggestionsAsync(
        CancellationToken cancellationToken = default)
    {
        // TODO: GetShareSuggestionsQuery
        return Ok(Array.Empty<UserSummaryDto>());
    }
}
