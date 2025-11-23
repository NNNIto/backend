// src/Foodstagram.Api/Controllers/StoryController.cs
using Foodstagram.Api.Dtos.Feed;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Foodstagram.Application.Stories.GetStories;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public StoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// ストーリー一覧を取得
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoryDto>>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        // TODO: Application 層の GetStoriesQuery を呼ぶ
        // var result = await _mediator.Send(new GetStoriesQuery(), cancellationToken);
        // return Ok(result);

        // ひとまずモック
        var mock = new List<StoryDto>();
        return Ok(mock);
    }
}
