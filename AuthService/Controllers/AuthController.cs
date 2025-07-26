
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;
[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private IAuthService FAuthService;
    public AuthController(IAuthService authService)
    {
        FAuthService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        return Ok(FAuthService.Login(request));
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {

        return Ok(FAuthService.Refresh(request));
    }
}