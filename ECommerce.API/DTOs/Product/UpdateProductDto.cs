namespace ECommerce.API.DTOs.Product
{
    public class UpdateProductDto
    {
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
