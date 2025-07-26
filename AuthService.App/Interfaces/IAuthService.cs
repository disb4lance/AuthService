public interface IAuthService
{
    TokenResponse Login(LoginRequest request);
    TokenResponse Refresh(RefreshRequest request);
}