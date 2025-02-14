using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseEnrollment.Core.Models;
using OnlineCourseEnrollment.Service;

namespace OnlineCourseEntrollment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        //GET : api/couses
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<CourseModel>>> GetAllCoursesAsync()
        {
            var courses = await courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        //Get : api/courses/byCategory?categoryId:1
        [HttpGet("Category/{categoryId}")]
        [AllowAnonymous]
        public async Task<ActionResult<CourseModel>> GetAllCoursesByCategoryIdAsync([FromRoute] int categoryId)
        {
            var courses =  await courseService.GetAllCoursesAsync(categoryId);
            return Ok(courses);
        }

        //Get : api/course/details
        [HttpGet("Detail/{courseId}")]
        public async Task<ActionResult<CourseDetailModel>> GetCousesDetailsAsync(int courseId)
        {
            var courseDetails = await courseService.GetCousesDetailsAsync(courseId);
            if (courseDetails == null)
            {
                return NotFound();
            }
            return Ok(courseDetails);
        }
    }
}
