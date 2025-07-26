
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;
[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // 1. Проверка учетных данных
        var user = await _userService.ValidateCredentialsAsync(request.Email, request.Password);
        if (user == null) return Unauthorized();

        // 2. Генерация токенов
        var accessToken = GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        // 3. Сохранение refresh-токена
        await _dbContext.RefreshTokens.AddAsync(new RefreshToken
        {
            TokenId = refreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        });

        // 4. Ответ
        return Ok(new TokenResponse(accessToken, refreshToken, 300));
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {
        // 1. Проверка refresh-токена
        var token = await _dbContext.RefreshTokens
            .FirstOrDefaultAsync(t => t.TokenId == request.RefreshToken);

        if (token == null || token.Revoked || token.ExpiresAt < DateTime.UtcNow)
            return Unauthorized();

        // 2. Проверка пользователя
        var user = await _userService.GetUserAsync(token.UserId);
        if (user == null) return Unauthorized();

        // 3. Генерация новых токенов
        var newAccessToken = GenerateJwtToken(user);
        var newRefreshToken = GenerateRefreshToken();

        // 4. Инвалидация старого токена
        token.Revoked = true;

        // 5. Ответ
        return Ok(new TokenResponse(newAccessToken, newRefreshToken, 300));
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        // 1. Инвалидация refresh-токена
        var token = await _dbContext.RefreshTokens
            .FirstOrDefaultAsync(t => t.TokenId == request.RefreshToken);

        if (token != null)
        {
            token.Revoked = true;
            await _dbContext.SaveChangesAsync();
        }

        // 2. Добавление access-токена в blacklist
        var jti = User.Claims.First(c => c.Type == "jti").Value;
        await _redis.StringSetAsync($"blacklist:{jti}", "1", TimeSpan.FromMinutes(5));

        return Ok();
    }
}