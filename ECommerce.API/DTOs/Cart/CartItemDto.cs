namespace ECommerce.API.DTOs.Cart
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public int ProductId {  get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }   
        public int Quantity { get; set; }
        public double TotalAmount { get; set; } 

    }
}
