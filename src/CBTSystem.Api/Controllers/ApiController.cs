using CBTSystem.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace CBTSystem.Api.Controllers;
[ApiController]
public class ApiController:ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if(errors.Count is  0)
        {
            return Problem();
        }
        if(errors.All(error=>error.Type==ErrorType.Validation))
        {
            return ValidationProblem();
        }
        HttpContext.Items[HttpContextKeys.Errors]=errors;
        var firstError=errors[0];
        return Problem(firstError);

    }
    private IActionResult Problem(Error firstError)
    {
        var statusCode=firstError.Type switch
        {
            ErrorType.Conflict=>StatusCodes.Status409Conflict,
            ErrorType.NotFound=>StatusCodes.Status404NotFound,
            ErrorType.Validation=>StatusCodes.Status400BadRequest,
            _=>StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode:statusCode,title:firstError.Description);
    }
}
