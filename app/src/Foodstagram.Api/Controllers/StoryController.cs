using AutoMapper;
using Foodstagram.Api.Dtos.Feed;
using Foodstagram.Application.Stories.GetStories;
using Foodstagram.Application.Stories.GetStoryDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public StoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// ストーリー一覧を取得
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoryDto>>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetStoriesQuery(), cancellationToken);
        var dto = _mapper.Map<IEnumerable<StoryDto>>(result);
        return Ok(dto);
    }

    /// <summary>
    /// ストーリー詳細を取得
    /// </summary>
    [HttpGet("{storyId:long}")]
    public async Task<ActionResult<StoryDetailDto>> GetDetailAsync(
        long storyId,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetStoryDetailQuery(storyId), cancellationToken);
        var dto = _mapper.Map<StoryDetailDto>(result);
        return Ok(dto);
    }
}
