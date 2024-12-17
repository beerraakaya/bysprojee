using bysprojee.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace bysprojee.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseSercice)
        {
            _courseService = courseSercice;
        }
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.GetCoursesAsync();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }


    }
}
