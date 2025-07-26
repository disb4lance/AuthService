namespace AuthServiceDomain.Entities;

public class RefreshToken
{
    public string Token { get; set; }      // Уникальный токен
    public DateTime ExpiresAt { get; set; } // Срок действия
    public bool IsRevoked { get; set; }    // Отозван ли токен
    public Guid UserId { get; set; }       // Внешний ключ

    // Связь
    public User User { get; set; }
}