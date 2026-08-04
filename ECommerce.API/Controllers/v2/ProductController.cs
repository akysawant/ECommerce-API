//using ECommerce.API.Common.Response;
//using ECommerce.API.DTOs.Product;
//using ECommerce.API.Interfaces.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Asp.Versioning;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace ECommerce.API.Controllers.v2
//{
//    //[Authorize]
//    [ApiController]
//    [ApiVersion(2.0)]
//    [Route("api/v{version:apiVersion}/[controller]")]
//    public class ProductController : ControllerBase
//    {
//        private readonly IProductService _productService;

//        public ProductController(IProductService productService)
//        {
//            _productService = productService;
//        }


//        // GET: api/<ProductController>
//        [HttpGet]
//        [MapToApiVersion("2.0")]
//        public async Task<IActionResult> Getallv2()
//        {
//            var products = await _productService.GetAllAsync();

//            return Ok(ApiResponse<IEnumerable<ProductDto>>.SuccessResponse(
//                products,
//                "product retireved sucessfully"));
//        }
//    }
//}
