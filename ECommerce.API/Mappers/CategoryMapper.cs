using ECommerce.API.DTOs.Category;
using ECommerce.API.Models;

namespace ECommerce.API.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public static Category ToEntity(this CreateCategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }

        public static Category ToEntity(this UpdateCategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }
    }
}
