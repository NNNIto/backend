using Foodstagram.Api.Dtos.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Foodstagram.Application.Shares.GetShareSuggestions;

namespace Foodstagram.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShareController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ShareController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// 共有候補ユーザー一覧
    /// </summary>
    [HttpGet("suggestions")]
    public async Task<ActionResult<IEnumerable<UserSummaryDto>>> GetSuggestionsAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetShareSuggestionsQuery(), cancellationToken);
        var dto = _mapper.Map<IEnumerable<UserSummaryDto>>(result);
        return Ok(dto);
    }
}
