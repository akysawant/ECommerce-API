using ECommerce.API.Models;

namespace ECommerce.API.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantiry { get; set; }
        public User User { get; set; } = null;
        public Product Product { get; set; } = null;
    }
}
