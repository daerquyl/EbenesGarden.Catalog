using Catalog.Repositories;
using Catalog.Web.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Web.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<CategoryHierarchyDto>> Get()
        {
            var categories = await _repository.GetCategories();
            var response = CategoryHierarchyDto.From(categories);
            return Ok(response);
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(string id)
        {
            var category = await _repository.GetCategory(id);
            if(category == null)
            {
                return NotFound();
            }

            var response = CategoryDto.From(category);
            return Ok(category);
        }

        // GET: api/categories/5/children
        [HttpGet("{categoryId}/children")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetChildren(string categoryId)
        {
            var categories = await _repository.GetCategoryChildren(categoryId);
            var response = categories.Select(category => CategoryDto.From(category)).ToList();
            return Ok(response);
        }

        // GET: api/categories/5/children
        [HttpGet("{categoryId}/children")]
        public async Task<ActionResult<CategoryDto>> GetCategoriesOfFamilyChildren(string categoryId)
        {
            var categories = await _repository.GetCategoryChildren(categoryId);
            var response = categories.Select(category => CategoryDto.From(category)).ToList();
            return Ok(response);
        }

        // GET api/categories/families
        [HttpGet("/families")]
        public async Task<ActionResult<IEnumerable<CategoryFamilyDto>>> GetFamilies()
        {
            var categoriesFamilies = await _repository.GetCategoriesFamilies();
            var response = categoriesFamilies.Select(family => CategoryFamilyDto.From(family)).ToList();
            return Ok(response);
        }

        // GET api/categories/families/5
        [HttpGet("/families/{familyId}")]
        public async Task<ActionResult<IEnumerable<CategoryFamilyDto>>> GetFamily(string familyId)
        {
            var categoryFamily = await _repository.GetCategoryFamily(familyId);
            return Ok(CategoryFamilyDto.From(categoryFamily));
        }

        // POST api/categories
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto request)
        {
            try
            {
                var category = await _repository.AddCategory(request.ToCategory());
                return CreatedAtAction(nameof(Get), new { id = category.Id }, CategoryDto.From(category));
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest();
            }
        }

        // POST api/categories/families
        [HttpPost("/families")]
        public async Task<IActionResult> Post([FromBody] CategoryFamilyDto request)
        {
            try
            {
                var family = await _repository.AddCategoryFamily(request.ToCategoryFamily());
                return CreatedAtAction(nameof(Get), new { id = family.Id }, CategoryFamilyDto.From(family));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest();
            }
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CategoryDto request)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }
            await _repository.UpdateCategory(request.ToCategory());
            return Ok();
        }

        // PUT api/categories/family/5
        [HttpPut("families/{familyId}")]
        public async Task<IActionResult> Put(string familyId, [FromBody] CategoryFamilyDto request)
        {
            if (!CategoryFamilyExists(familyId))
            {
                return NotFound();
            }
            await _repository.UpdateCategoryFamily(request.ToCategoryFamily());
            return Ok();
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!CategoryExists(id))
            {
                return BadRequest();
            }
            await _repository.DeleteCategory(id);
            return Ok();
        }

        // DELETE api/categories/families/5
        [HttpDelete("families/{familyId}")]
        public async Task<IActionResult> DeleteFamily(string familyId)
        {
            if (!CategoryFamilyExists(familyId))
            {
                return BadRequest();
            }
            await _repository.DeleteCategory(familyId);
            return Ok();
        }

        private bool CategoryExists(string id)
        {
            return false;
        }

        private bool CategoryFamilyExists(string id)
        {
            return false;
        }
    }
}
