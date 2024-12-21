using bysprojee.Model;

namespace bysprojee.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();//Tüm öğrencileri getirir
        Task<Student> GetStudentByIdAsync(int id);//ID ye göre öğrenci getirir
        Task<Student> AddStudentAsync(Student student);//yeni öğrenci ekle
        Task<Student> UpdateStudentAsync(Student student);//öğrenci bilgilerini güncelle
        Task<Student> DeleteStudentAsync(int id);//öğrenci sil
    }
}
