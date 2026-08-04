namespace ECommerce.API.DTOs.Cart
{
    public class CartDto
    {
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public double GrandTotal { get; set; }  

    }
}
