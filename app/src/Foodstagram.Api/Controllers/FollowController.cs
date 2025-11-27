using Foodstagram.Api.Dtos.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Foodstagram.Application.Follows.GetFollowers;
using Foodstagram.Application.Follows.GetFollowing;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FollowController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FollowController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    
    
    
    [HttpGet("followers")]
    public async Task<ActionResult<IEnumerable<UserSummaryDto>>> GetFollowersAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetFollowersQuery(), cancellationToken);
        var dto = _mapper.Map<IEnumerable<UserSummaryDto>>(result);
        return Ok(dto);
    }

    
    
    
    [HttpGet("following")]
    public async Task<ActionResult<IEnumerable<UserSummaryDto>>> GetFollowingAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetFollowingQuery(), cancellationToken);
        var dto = _mapper.Map<IEnumerable<UserSummaryDto>>(result);
        return Ok(dto);
    }
}
