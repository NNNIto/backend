// src/Foodstagram.Api/Controllers/ActivityController.cs
using Foodstagram.Api.Dtos.Activity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Foodstagram.Application.Activities.GetActivities;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// アクティビティ（通知）一覧
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityItemDto>>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        // TODO: GetActivitiesQuery
        return Ok(Array.Empty<ActivityItemDto>());
    }
}
