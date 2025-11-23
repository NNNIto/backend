using Foodstagram.Api.Dtos.Activity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Foodstagram.Application.Activities.GetActivities;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ActivityController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// アクティビティ（通知）一覧
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityItemDto>>> GetAsync(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 30,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetActivitiesQuery(page, pageSize), cancellationToken);
        var dto = _mapper.Map<IEnumerable<ActivityItemDto>>(result);
        return Ok(dto);
    }
}
