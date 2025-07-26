using System;
using System.Collections.Generic;

namespace AuthServicesDomain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }        // Уникальный email
    public string PasswordHash { get; set; } // Хеш пароля (bcrypt)
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Связи
    public List<RefreshToken> RefreshTokens { get; set; } = new();
}