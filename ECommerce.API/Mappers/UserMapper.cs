using ECommerce.API.DTOs.Auth;
using ECommerce.API.Enum;
using ECommerce.API.Models;

namespace ECommerce.API.Mappers
{
    public static class UserMapper
    {
        public static User ToEntity(this RegisterDto dto, string passwordHash)
        {
            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = passwordHash,
                Role = UserRole.Customer,
                CreatedAt = DateTime.UtcNow
            };
        }

    }
}
