using Microsoft.AspNetCore.Mvc;


namespace bysprojee.Controller
{
   

    public class StudentController:ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;

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

    }
}
