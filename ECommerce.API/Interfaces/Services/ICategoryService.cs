using ECommerce.API.DTOs.Category;
using ECommerce.API.Models;

namespace ECommerce.API.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllAsync();
        public Task<CategoryDto> GetByIdAsync(int id);
        public Task<CategoryDto> GetByNameAsync(string name);
        public Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        public Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto dto);
        public Task<bool> DeleteAsync(int id);
    }
}
