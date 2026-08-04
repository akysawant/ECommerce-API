using ECommerce.API.DTOs.Product;
using ECommerce.API.Models;

namespace ECommerce.API.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryName = product.Category?.Name ?? string.Empty
            };
        }

        public static ProductDtoV2 ToDtoV2(this Product product)
        {
            return new ProductDtoV2
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryName = product.Category?.Name ?? string.Empty,
                ImageUrl = product.ImageUrl ?? string.Empty
            };
        }

        public static Product ToEntity(this CreateProductDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };
        }

        public static Product ToEntity(this UpdateProductDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };
        }
    }
}
