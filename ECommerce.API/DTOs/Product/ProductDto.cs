namespace ECommerce.API.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public int Stock { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
