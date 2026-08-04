using ECommerce.API.DTOs.Auth;

namespace ECommerce.API.Interfaces.Services
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterDto dto);
        Task<LoginResponseDto> LoginAsync(LoginDto dto);
    }
}
