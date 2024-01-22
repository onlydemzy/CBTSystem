using CBTSystem.Contracts.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CBTSystem.Api.Controllers;

[Route("api/test")]
public class TestController:ApiController
{
    [Route("createtest")]
    [Authorize]
    public IActionResult CreateTest(CreateTestRequest request)
    {
        
        return Ok(request);
    }
}