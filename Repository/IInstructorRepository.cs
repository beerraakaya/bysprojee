using bysprojee.Model;

namespace bysprojee.Repository
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<Instructor>> GetInstructorAsync();//tüm akademisyenleri getir

        Task<Instructor> GetInstructorByIdAsync(int id);//ıd ye göre akademisyen getir
        Task<Instructor> AddInstructorAsync(Instructor instructor);
        Task<Instructor> UpdateInstructorAsync(Instructor instructor);
        Task<Instructor> DeleteInstructorAsync(int id);

    }
}
