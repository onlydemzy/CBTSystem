using CBTSystem.Application.Authentication.Commands;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBTSystem.Api.Controllers;
[Route("api/auth")]
public class AuthenticationController(ISender sender):ApiController
{
    ISender _mediatr=sender;
    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserCommand request)
    {
        ErrorOr<string> result=await _mediatr.Send(request);
        return result.Match(Ok,errors=>Problem(errors));
        //return result.Match(result=>
        //    Ok(result),errors=>Problem(errors));
    }
}