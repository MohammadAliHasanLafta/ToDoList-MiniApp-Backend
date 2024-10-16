using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Infrastructure.Service;

public class ProfileService : IProfileService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public ProfileService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetUserId()
    {
        return _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
