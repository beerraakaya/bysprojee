using bysprojee.Data;
using bysprojee.Model;
using bysprojee.Repository;
using Microsoft.EntityFrameworkCore;

namespace bysprojee.Service
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _studentRepository.AddStudentAsync(student);
        }
        public async Task<Student> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateStudentAsync(student);
        }
        public async Task<Student> DeleteStudentAsync(int id)
        {
            return await _studentRepository.DeleteStudentAsync(id);
        }
        public async Task<bool> AuthenticateUserAsync(int username, string password)
        {
            // Kullanıcıyı veritabanında kontrol edin.
            var user = await context.Students
                .FirstOrDefaultAsync(s => s.Student_ID== username && s.Password == password);

            return user != null; // Kullanıcı bulunursa true döner.
        }

    }
}
