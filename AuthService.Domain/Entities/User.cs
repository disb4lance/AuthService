using System;
using System.Collections.Generic;

namespace AuthService.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; } // bcrypt hash
    public bool IsEmailVerified { get; set; } = false;
    public bool IsActive { get; set; } = true;
    
    // Навигационные свойства
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}