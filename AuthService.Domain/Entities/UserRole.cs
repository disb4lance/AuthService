namespace AuthService.Domain.Entities;

public class UserRole
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
    
    // Навигационные свойства
    public User User { get; set; }
    public Role Role { get; set; }
}