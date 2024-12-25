using bysprojee.Model;
using bysprojee.Repository;
using bysprojee.Service;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;


namespace bysprojee.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        private readonly StudentRepository _studentRepository;

        public StudentController(StudentService studentService, StudentRepository studentRepository)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetStudentCourses(int id)
        {
            var Courses = await _studentRepository.GetStudentCoursesAsync(id);
            if (Courses == null || !Courses.Any())
            {
                return NotFound("Ders Bulunamadı.");
            }
            return Ok(Courses);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdStudent = await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Student_ID }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != student.Student_ID) return BadRequest("ID uyuşmuyor.");
            var updatedStudent = await _studentService.UpdateStudentAsync(student);
            if (updatedStudent == null) return NotFound();
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deletedStudent = await _studentService.DeleteStudentAsync(id);
            if (deletedStudent == null) return NotFound();
            return Ok(deletedStudent);
        }

        // ... existing code ...

        // öğrenciyi sisteme kaydetme 
        [HttpPost("register")]
        public async Task<IActionResult> RegisterStudent([FromBody] Student student)
        {
            if (string.IsNullOrEmpty(student.Username) || string.IsNullOrEmpty(student.Password))
            {
                return BadRequest("Kullanıcı adı ve şifre boş olamaz.");
            }
           student.Password = BCrypt.Net.BCrypt.HashPassword(student.Password);
            await _studentService.AddStudentAsync(student);
            return Ok("Kayıt başarılı.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var student= await _studentService.GetStudentByIdAsync(login.Username);

            if (student == null)
            {
                return Unauthorized("Kullanıcı bulunamadı.");
            }
            //şifre kontrolü
            if (!BCrypt.Net.BCrypt.Verify(login.Password, student.Password))
            {
                return Unauthorized("şifre hatalı.");
            }
            //başarılı giriş
            return Ok(new
            {
                Message= "Giriş başarılı.",
                Student_ID = student.Student_ID,
                Username = student.Username,
                Firstname=student.First_Name, 

            });
        }

    }

}
