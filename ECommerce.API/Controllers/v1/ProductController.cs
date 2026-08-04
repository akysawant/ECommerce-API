using ECommerce.API.Common.Response;
using ECommerce.API.DTOs.Product;
using ECommerce.API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ECommerce.API.Services;
using ECommerce.API.Features.Products.Queries.GetAllProducts;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.API.Controllers.v1
{
    //[Authorize]
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductController(
            IProductService productService,
            IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }


        // GET: api/<ProductController>
        [HttpGet]
        [MapToApiVersion(1.0)]
        public async Task<IActionResult> Getall()
        {
            var products = await _mediator.Send(new GetAllProductQuery());

            return Ok(ApiResponse<IEnumerable<ProductDto>>.SuccessResponse(
                products,
                "product retireved sucessfully"));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(ApiResponse<ProductDto>.SuccessResponse(
                product,
                "product retireved successfully"));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productService.CreateAsync(dto);

            return Created("post",
                ApiResponse<ProductDto>.SuccessResponse(
                    product,
                    "product created successfully"));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productService.UpdateAsync(id, dto);

            return Ok(
                ApiResponse<ProductDto>.SuccessResponse(
                    product,
                    "Product Updated Succefully"));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _productService.DeleteAsync(id);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("tracker")]
        public IActionResult GetTracker()
        {
            return Ok(_productService.GetTrackerDetails());
        }

        [HttpGet("test/notification")]
        public IActionResult Test()
        {
            var notificationService = new NotificationService();

            _productService.AddProduct("akshy@gmail.com", notificationService.SendEmial);

            return Ok();
        }
    }
}
