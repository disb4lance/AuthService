
using AuthService.App.Interfaces;
using AuthService.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private IAuthorizeService FAuthService;
    public AuthController(IAuthorizeService authService)
    {
        FAuthService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        return Ok(await FAuthService.Login(request));
    }

    [HttpPost("registration")]
    public async Task<IActionResult> RegistrationAsync([FromBody] LoginRequest request)
    {
        return Ok(await FAuthService.Registration(request));
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync([FromBody] string token)
    {
        return Ok(await FAuthService.RefreshTokenAsync(token));
    }
}