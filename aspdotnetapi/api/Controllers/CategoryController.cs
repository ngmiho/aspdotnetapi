using aspdotnetapi.api.Interfaces;
using aspdotnetapi.api.Models;
using aspdotnetapi.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetapi.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = categoryRepository.GetCategories();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);
        }

        [HttpGet("{categoryID}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryID)
        {   
            if (!categoryRepository.HasCategory(categoryID))
                return NotFound();
            var category = categoryRepository.GetCategory(categoryID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] Category category) 
        {
            if (!categoryRepository.Create(category))
                return StatusCode(500, ModelState);
            return Ok(200);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            if (category == null)
                return BadRequest(ModelState);
            if (!categoryRepository.HasCategory(category.Id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!categoryRepository.Update(category))
                return StatusCode(500, ModelState);
            return Ok(200);
            //return NoContent();
        }

        [HttpDelete("{categoryID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryID)
        {
            if (categoryID == null)
                return BadRequest(ModelState);
            if (!categoryRepository.HasCategory(categoryID))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!categoryRepository.Delete(categoryID))
                return StatusCode(500, ModelState);
            return Ok(200);
            //return NoContent();
        }
    }
}
