using Foodstagram.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Foodstagram.Infrastructure.Identity;

public sealed class AuthUserProvider : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthUserProvider(IHttpContextAccessor accessor)
    {
        _httpContextAccessor = accessor;
    }

    public long UserId
    {
        get
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var sub = user?.FindFirst("sub")?.Value;
            return long.TryParse(sub, out var id) ? id : 1; 
        }
    }
}
