using bysprojee.Data;
using bysprojee.Model;
using Microsoft.EntityFrameworkCore;

namespace bysprojee.Repository
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);//yeni öğrenci ekle
            await _context.SaveChangesAsync();//değişikleri kaydet
            return student;
        }
        public async Task<Student> UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);//ÖĞRENCİYİ BUL
            if (student != null)
            {
                _context.Students.Remove(student);//öğrenciyi sil
                await _context.SaveChangesAsync();//değişikleri kaydet

            }
            return student;
        }


    }
}
