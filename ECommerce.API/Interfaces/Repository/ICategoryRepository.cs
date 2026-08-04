using ECommerce.API.Models;

namespace ECommerce.API.Interfaces.Repository
{
    public interface ICategoryRepository 
    {
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int Id);
        public Task<Category?> GetByNameAsync(string Name);
        public Task<Category> AddAsysnc(Category category);
        public Task<Category?> UpdateAsysnc(int Id, Category category);
        public Task<bool> DeleteAsync(int id);
    }
}
