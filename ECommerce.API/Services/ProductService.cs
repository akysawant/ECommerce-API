using ECommerce.API.Common.Exceptions;
using ECommerce.API.Delegate;
using ECommerce.API.DTOs.Product;
using ECommerce.API.Interfaces.Repository;
using ECommerce.API.Interfaces.Services;
using ECommerce.API.Mappers;
using ECommerce.API.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ECommerce.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMemoryCache _cache;
        private readonly RequestTracker _tracker;

        public ProductService(
            IProductRepository productRepository, 
            IMemoryCache cache,
            RequestTracker tracker)
        {
            _productRepository = productRepository;
            _cache = cache;
            _tracker = tracker;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = dto.ToEntity();

            var createdProdcut = await _productRepository.AddAsync(product);

            _cache.Remove("products");

            return createdProdcut.ToDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            const string cacheKey = "products";

            if ( _cache.TryGetValue(cacheKey, out IEnumerable<ProductDto>? products))
            {
                return products!;
            }

            var productEntity = await _productRepository.GetAllAsync();

            products = productEntity.Select(x => x.ToDto());

            _cache.Set(cacheKey, products, TimeSpan.FromMinutes(5));

            return products;
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException("Product Not Found");

            return product.ToDto();
        }

        public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = dto.ToEntity();

            var updatedProduct = await _productRepository.UpdateAsync(id, product);

            if (updatedProduct == null)
                throw new NotFoundException("product not found");

            return updatedProduct.ToDto();
        }

        public void AddProduct(string email, NotificationDelegate notification)
        {
            Console.WriteLine("Product Saved");

            notification(email);
        }

        public object GetTrackerDetails()
        {
            return new
            {
                ServiceId = _tracker.Id,
                RepositoryId = _productRepository.GetTrackerId()
            };
        }
    }
}
