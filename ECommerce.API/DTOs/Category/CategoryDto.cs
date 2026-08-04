using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerce.API.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
