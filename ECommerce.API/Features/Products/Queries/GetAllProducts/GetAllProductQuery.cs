using ECommerce.API.DTOs.Product;
using MediatR;

namespace ECommerce.API.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDto>>
    {

    }
}
