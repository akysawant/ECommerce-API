using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs.Cart
{
    public class AddToCartDto
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1,100)]
        public int Quantity { get; set; }
    }
}
