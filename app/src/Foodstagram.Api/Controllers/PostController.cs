// src/Foodstagram.Api/Controllers/PostController.cs
using Foodstagram.Api.Dtos.Feed;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Foodstagram.Application.Posts.GetPostDetail;
// using Foodstagram.Application.Posts.ToggleLike;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// ìäçeè⁄ç◊ÇéÊìæ
    /// </summary>
    [HttpGet("{postId:long}")]
    public async Task<ActionResult<PostDetailDto>> GetDetailAsync(
        long postId,
        CancellationToken cancellationToken = default)
    {
        // TODO: GetPostDetailQuery ÇåƒÇ‘
        // var result = await _mediator.Send(new GetPostDetailQuery(postId), cancellationToken);
        // return Ok(result);

        return Ok(new PostDetailDto
        {
            Id = postId,
            ImageUrl = "",
            Caption = "",
            LikeCount = 0,
            CommentCount = 0,
            IsLiked = false
        });
    }

    /// <summary>
    /// Ç¢Ç¢ÇÀÉgÉOÉã
    /// </summary>
    [HttpPost("{postId:long}/like")]
    public async Task<IActionResult> ToggleLikeAsync(
        long postId,
        CancellationToken cancellationToken = default)
    {
        // TODO: ToggleLikeCommand ÇåƒÇ‘
        // await _mediator.Send(new ToggleLikeCommand(postId), cancellationToken);
        return NoContent();
    }
}
