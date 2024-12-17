using bysprojee.Model;
using bysprojee.Service;
using Microsoft.AspNetCore.Mvc;



namespace bysprojee.Controller
{
[ApiController]
[Route("api/[controller]")]
    public class InstructorController:ControllerBase
    {
        private readonly InstructorService _instructorService;
        public InstructorController(InstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors = await _instructorService.GetInstructorAsync();
            return Ok(instructors);
        }
        [HttpPost]
        public async Task<IActionResult> AddInstructor([FromBody] Instructor instructor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdInstructor = await _instructorService.AddInstructorAsync(instructor);
            return CreatedAtAction(nameof(AddInstructor), createdInstructor);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, [FromBody] Instructor instructor)
        {
            if (id != instructor.Instructor_ID) return BadRequest();
            var updatedInstructor = await _instructorService.UpdateInstructorAsync(instructor);
            if (updatedInstructor == null) return NotFound();
            return Ok(updatedInstructor);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var deletedInstructor = await _instructorService.DeleteInstructorAsync(id);
            if (deletedInstructor == null) return NotFound();
            return Ok(deletedInstructor);
        }

    }
}
