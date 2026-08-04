using ECommerce.API.Delegate;
using ECommerce.API.DTOs.Product;
using ECommerce.API.Models;

namespace ECommerce.API.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetByIdAsync(int id);

        Task<ProductDto> CreateAsync(CreateProductDto dto);

        Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto);

        Task<bool> DeleteAsync(int id);

        void AddProduct(string email, NotificationDelegate notification);

        object GetTrackerDetails();
    }
}
