using ECommerce.API.Data;
using ECommerce.API.Interfaces.Repository;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext _context;

        public CategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsysnc(Category category)
        {
            var addedCategory =  await _context.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingCategoy = await GetByIdAsync(id);

            if (existingCategoy == null)
                return false;
            
            _context.Remove(existingCategoy);
            await _context.SaveChangesAsync();

            return true;
                
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => string.Equals(c.Name, name));
        }

        public async Task<Category?> UpdateAsysnc(int id, Category category)
        {
            var existingCategory = await GetByIdAsync(id);

            if (existingCategory == null)
                return null;

            existingCategory.Update(category.Name, category.Description);

            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}
