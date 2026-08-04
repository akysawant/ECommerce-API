using ECommerce.API.Models;

namespace ECommerce.API.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
    }
}
