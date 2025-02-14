using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseEnrollment.Service;

namespace OnlineCourseEntrollment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryService categoryService;

        public CourseCategoryController(ICourseCategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }


            return Ok(category);//olkay means the status code is 200
                                }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetCourseCategoriesAsync();
            return Ok(categories);
        }
    }
}
