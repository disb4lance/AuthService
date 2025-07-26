public class AuthService : IAuthService
{
    public async TokenResponse Login(LoginRequest request)
    {
        // 1. Проверка учетных данных
        // var user = await _userService.ValidateCredentialsAsync(request.Email, request.Password);
        var user = true;
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

        return new TokenResponse(accessToken, refreshToken, 300);
    }

    public async TokenResponse Refresh(RefreshRequest request)
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
        
        return new TokenResponse(newAccessToken, newRefreshToken, 300);
     }
}