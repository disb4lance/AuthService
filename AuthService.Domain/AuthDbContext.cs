using AuthServiceDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthServiceDomain;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) 
        : base(options) { }

    // DbSets для всех сущностей
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<JwtBlacklistItem> JwtBlacklist => Set<JwtBlacklistItem>();

}