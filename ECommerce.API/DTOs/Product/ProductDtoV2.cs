using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ECommerce.API.DTOs.Product
{
    public class ProductDtoV2
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public int Stock { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
