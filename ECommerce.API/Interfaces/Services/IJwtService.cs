using ECommerce.API.Models;

namespace ECommerce.API.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
