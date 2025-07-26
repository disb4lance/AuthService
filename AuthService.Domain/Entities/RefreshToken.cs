namespace AuthService.Domain.Entities;

public class RefreshToken
{
    public string TokenId { get; set; } // GUID или JTI
    public Guid UserId { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; } = false;
    public string DeviceInfo { get; set; } // Например: "Chrome, Windows 10"
    
    // Навигационное свойство
    public User User { get; set; }
}