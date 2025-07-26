namespace AuthServiceDomain.Entities;

public class JwtBlacklistItem
{
    public string Jti { get; set; } // JWT ID
    public DateTime ExpiresAt { get; set; }
}