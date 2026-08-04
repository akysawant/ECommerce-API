using ECommerce.API.Interfaces.Services;
using ECommerce.API.DTOs.Category;
using ECommerce.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ECommerce.API.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await _categoryService.GetAllAsync();
            return Ok(category);
        }

        // GET api/<CategoryController>/d5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var category = await _categoryService.GetByNameAsync(name);

            if (category == null)
                return NotFound();

            return Ok(category);
        }


        [ServiceFilter(typeof(AuditLogFIlter))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var categoryDto = await _categoryService.CreateAsync(dto);

            return Created("Post", categoryDto);

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryService.UpdateAsync(id, dto);

            if (category == null)
                return NotFound();

            return Ok(category);
        }


        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _categoryService.DeleteAsync(id);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
