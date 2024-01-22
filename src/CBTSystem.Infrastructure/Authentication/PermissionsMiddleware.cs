using System.Formats.Asn1;
using CBTSystem.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CBTSystem.Infrastructure.Authentication;
public class PermissionsMiddleware(RequestDelegate next, ILogger<PermissionsMiddleware> logger)
{
    private readonly RequestDelegate _next=next;
    private readonly ILogger<PermissionsMiddleware> _logger=logger;
    /*public async Task InvokeAsync(HttpContext context, IUserPermissionService userPermissionService)
    {
        
    }*/
}