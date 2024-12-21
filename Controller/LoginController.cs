using bysprojee.Service;
using Microsoft.AspNetCore.Mvc;

namespace bysprojee.Controller
{
    public class LoginController: Controller

    {
        private readonly StudentService _studentService;
        public LoginController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(string Student_ID,string Password)
        {
            
        }
    }
}
