using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CBTSystem.Api.Controllers;

public class ErrorController:ApiController
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception=HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem();
    }
}