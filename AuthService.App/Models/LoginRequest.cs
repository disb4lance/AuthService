using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
    /// <summary>
    /// Email пользователя (обязательное поле)
    /// </summary>
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Некорректный формат email")]
    public string Email { get; set; }

    /// <summary>
    /// Пароль пользователя (обязательное поле)
    /// </summary>
    [Required(ErrorMessage = "Пароль обязателен")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 100 символов")]
    public string Password { get; set; }

    /// <summary>
    /// Опционально: флаг для OAuth-аутентификации
    /// </summary>
    public bool IsOAuth { get; set; } = false;

    /// <summary>
    /// Требуется для OAuth
    /// </summary>
    public string OAuthProvider { get; set; }

    /// <summary>
    /// Требуется для OAuth: токен от провайдера
    /// </summary>
    public string OAuthToken { get; set; }
}