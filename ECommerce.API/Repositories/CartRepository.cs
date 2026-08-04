using ECommerce.API.Data;
using ECommerce.API.DTOs.Cart;
using ECommerce.API.Entities;
using ECommerce.API.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ECommerceDbContext _context;

        public CartRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCartAsync(int userId, AddToCartDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == dto.ProductId);

            if (product == null)
                return false;

            var carItem = await _context.CartItems
                .FirstOrDefaultAsync(c =>
                    c.UserId == userId &&
                    c.ProductId == dto.ProductId);

            if(carItem != null)
            {
                carItem.Quantiry = dto.Quantity;
            }
            else
            {
                carItem = new CartItem
                {
                    UserId = userId,
                    ProductId = dto.ProductId,
                    Quantiry = dto.Quantity
                };

                await _context.CartItems.AddAsync(carItem);
            }

            await _context.SaveChangesAsync();
            
            return true;
        }

        public Task<bool> ClearCartAysnc(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> GetCartAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemAsync(int cartItemId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateQuantityAsync(int cartItemId, int quantity, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
