using Foodstagram.Api.Dtos.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Foodstagram.Application.Profiles.GetCurrentProfile;
using Foodstagram.Application.Profiles.GetMyPosts;
using Foodstagram.Application.Profiles.UpdateProfile;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProfileController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    
    
    
    [HttpGet("me")]
    public async Task<ActionResult<ProfileHeaderDto>> GetCurrentAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetCurrentProfileQuery(), cancellationToken);
        var dto = _mapper.Map<ProfileHeaderDto>(result);
        return Ok(dto);
    }

    
    
    
    [HttpGet("me/posts")]
    public async Task<ActionResult<IEnumerable<ProfilePostDto>>> GetMyPostsAsync(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 30,
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetMyPostsQuery(page, pageSize), cancellationToken);
        var dto = _mapper.Map<IEnumerable<ProfilePostDto>>(result);
        return Ok(dto);
    }

    
    
    
    [HttpPut("me")]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateProfileRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateProfileCommand(
            request.DisplayName,
            request.Bio,
            request.AvatarUrl
        );

        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }
}
