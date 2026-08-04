using ECommerce.API.DTOs.Product;
using ECommerce.API.Interfaces.Repository;
using ECommerce.API.Mappers;
using ECommerce.API.Models;
using ECommerce.API.Repositories;
using MediatR;
using System.Collections;

namespace ECommerce.API.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();

            return products.Select(x => x.ToDto());
        }
    }
}
