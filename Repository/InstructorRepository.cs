using bysprojee.Data;
using bysprojee.Model;
using Microsoft.EntityFrameworkCore;

namespace bysprojee.Repository
{
    public class InstructorRepository:IInstructorRepository
    {
        private readonly AppDbContext _context;
        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Instructor>> GetInstructorsAsync()
        {
            return await _context.Instructors.ToListAsync();
        }
        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _context.Instructors.FindAsync(id);
        }
        public async Task<Instructor> UpdateInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }
        public async Task<Instructor> AddInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }
        public async Task<Instructor> DeleteInstructorAsync(int id)
        {
            var Instructor = await _context.Instructors.FindAsync(id);
            if (Instructor != null)
            {
                _context.Instructors.Remove(Instructor);
                await _context.SaveChangesAsync();
            }
            return Instructor;
        }

        public Task<IEnumerable<Instructor>> GetInstructorAsync()
        {
            throw new NotImplementedException();
        }

    }
}
