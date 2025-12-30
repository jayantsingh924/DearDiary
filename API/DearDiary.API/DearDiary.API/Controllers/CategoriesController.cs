using DearDiary.API.Data;
using DearDiary.API.Models.Domain;
using DearDiary.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DearDiary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            // Implementation for creating a category will go here.
            //Map DTO to Domain Model
            
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            //Domain Model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);

        }
    }
}
