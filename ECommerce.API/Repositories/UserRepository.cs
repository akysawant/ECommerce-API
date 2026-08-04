using ECommerce.API.Interfaces.Repository;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceDbContext _context;

        public UserRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
