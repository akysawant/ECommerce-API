using ECommerce.API.DTOs.Category;
using ECommerce.API.DTOs.Product;
using ECommerce.API.Interfaces.Repository;
using ECommerce.API.Interfaces.Services;
using ECommerce.API.Mappers;

namespace ECommerce.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = dto.ToEntity();
            var addedCategory = await _categoryRepository.AddAsysnc(category);
            return addedCategory.ToDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var isDeleted = await _categoryRepository.DeleteAsync(id);
            return isDeleted;
        }

        async Task<IEnumerable<CategoryDto>> ICategoryService.GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => c.ToDto());
        }

        async Task<CategoryDto?> ICategoryService.GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return null;

            return category.ToDto();
        }

        async Task<CategoryDto?> ICategoryService.GetByNameAsync(string name)
        {
            var category = await _categoryRepository.GetByNameAsync(name);

            if (category == null)
                return null;

            return category.ToDto();
        }

        async Task<CategoryDto?> ICategoryService.UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = dto.ToEntity();
            var updatedCategory = await _categoryRepository.UpdateAsysnc(id, category);

            if (updatedCategory == null)
                return null;

            return updatedCategory.ToDto();

        }
    }
}
