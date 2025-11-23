using Foodstagram.Api.Dtos.Feed;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Foodstagram.Application.Stories.GetStories;
using Foodstagram.Api.Dtos.Feed.Foodstagram.Api.Dtos.Feed.Foodstagram.Api.Dtos.Feed;

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
}
