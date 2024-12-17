using bysprojee.Model;
using bysprojee.Repository;

namespace bysprojee.Service
{
    public class InstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<Instructor>> GetInstructorAsync()
        {
            return await _instructorRepository.GetInstructorAsync();
        }
        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _instructorRepository.GetInstructorByIdAsync(id);
        }
        public async Task<Instructor> AddInstructorAsync(Instructor instructor)
        {
            return await _instructorRepository.AddInstructorAsync(instructor);
        }
        public async Task<Instructor> UpdateInstructorAsync(Instructor instructor)
        {
            return await _instructorRepository.UpdateInstructorAsync(instructor);
        }
        public async Task<Instructor> DeleteInstructorAsync(int id)
        {
            return await _instructorRepository.DeleteInstructorAsync(id);
        }

    }
}
