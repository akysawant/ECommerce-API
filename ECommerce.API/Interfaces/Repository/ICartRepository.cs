using ECommerce.API.DTOs.Cart;

namespace ECommerce.API.Interfaces.Repository
{
    public interface ICartRepository
    {
        Task<bool> AddCartAsync(int userId, AddToCartDto dto);
        Task<CartDto> GetCartAsync(int userId);
        Task<bool> RemoveItemAsync(int cartItemId, int userId);
        Task<bool> ClearCartAysnc(int userId);
        Task<bool> UpdateQuantityAsync(int cartItemId, int quantity, int userId);

    }
}
