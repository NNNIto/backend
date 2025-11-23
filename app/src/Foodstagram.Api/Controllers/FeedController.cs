// src/Foodstagram.Api/Controllers/FeedController.cs
using Foodstagram.Api.Dtos.Feed;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
// Application
using Foodstagram.Application.Posts.GetFeed;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FeedController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Home
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<FeedResponseDto>> GetAsync(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var query = new GetFeedQuery(page, pageSize);
        var result = await _mediator.Send(query, cancellationToken);

        var dto = _mapper.Map<FeedResponseDto>(result);
        return Ok(dto);
    }
}
