namespace AuthService.App.Models;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }        // Уникальный email
    public string PasswordHash { get; set; } // Хеш пароля (bcrypt)
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}