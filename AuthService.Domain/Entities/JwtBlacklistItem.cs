using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain.Entities;

public class JwtBlacklistItem
{
    [Key]
    public Guid Id { get; set; } // Добавленный первичный ключ
    public string Jti { get; set; } // JWT ID
    public DateTime ExpiresAt { get; set; }
}