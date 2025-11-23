using Foodstagram.Api.Dtos.Feed;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Foodstagram.Application.Posts.GetPostDetail;
using Foodstagram.Application.Posts.ToggleLike;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PostController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// 投稿詳細取得
    /// </summary>
    [HttpGet("{postId:long}")]
    public async Task<ActionResult<PostDetailDto>> GetDetailAsync(
        long postId,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetPostDetailQuery(postId), cancellationToken);
        var dto = _mapper.Map<PostDetailDto>(result);
        return Ok(dto);
    }

    /// <summary>
    /// いいねトグル
    /// </summary>
    [HttpPost("{postId:long}/like")]
    public async Task<IActionResult> ToggleLikeAsync(
        long postId,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new ToggleLikeCommand(postId), cancellationToken);
        return NoContent();
    }
}
