using System.ComponentModel.DataAnnotations;

public class RefreshRequest
{
    /// <summary>
    /// Refresh-токен, полученный при входе (обязательное поле)
    /// </summary>
    [Required(ErrorMessage = "Refresh token обязателен")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// Опционально: устройство, с которого выполняется запрос
    /// </summary>
    public string DeviceId { get; set; }

    /// <summary>
    /// Опционально: IP-адрес клиента
    /// </summary>
    public string IpAddress { get; set; }
}