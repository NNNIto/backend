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

    public long UserId =>
        long.Parse(_httpContextAccessor.HttpContext!.User.FindFirst("sub")!.Value);
}
