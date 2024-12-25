using bysprojee.Data;
using bysprojee.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace bysprojee.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CourseController: ControllerBase
    {
        private readonly AppDbContext _context;
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
        [HttpGet]
        public IActionResult TestDatabaseConnection()
        {
            try
            {
                var courses = _context.Courses.ToList();//veritabanına bağlantı testi
                return Ok(courses);//bağlantı başarılıysa verileri döndür
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"veritabanı bağlantı hatası: {ex.Message}");//bağlantı başarısızsa hata mesajını döndür
            }
        }
    }
}
