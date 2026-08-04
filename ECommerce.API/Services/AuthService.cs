using ECommerce.API.DTOs.Auth;
using ECommerce.API.Interfaces.Repository;
using ECommerce.API.Interfaces.Services;
using ECommerce.API.Mappers;

namespace ECommerce.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return new RegisterResponseDto
                {
                    Success = false,
                    Message = "Email already exist"
                };
            }

            var passwordHash = _passwordHasher.Hash(dto.Password);

            var user = dto.ToEntity(passwordHash);

            await _userRepository.CreateAsync(user);

            return new RegisterResponseDto
            {
                Success = true,
                Message = "User registered successfully"
            };
        }

        async Task<LoginResponseDto> IAuthService.LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if(user == null)
                return GetLoginResponse(false, "Invalid Email or Password.");

            bool isPasswordValid = _passwordHasher.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
                return GetLoginResponse(false, "Invalid Email or Password.");

            var token = _jwtService.GenerateToken(user);

            return GetLoginResponse(true, "Login Successful.", token);
        }

        private static LoginResponseDto GetLoginResponse(bool success, string message, string? Token = null)
        {
            return new LoginResponseDto
            {
                Success = success,
                Message = message,
                Token = Token
            };
        }
    }
}
