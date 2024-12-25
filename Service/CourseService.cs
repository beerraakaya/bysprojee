using bysprojee.Model;
using bysprojee.Repository;

namespace bysprojee.Service
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public List<Course> GetCourses()
        {
            return new List<Course>();
        }
        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _courseRepository.GetCoursesAsync();
        }
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetCourseByIdAsync(id);
        }
        public async Task<Course> AddCourseAsync(Course course)
        {
            return await _courseRepository.AddCourseAsync(course);
        }
        public async Task<Course> UpdateCourseAsync(Course course)
        {
            return await _courseRepository.UpdateCourseAsync(course);
        }
        public async Task<Course> DeleteCourseAsync(int id)
        {
            return await _courseRepository.DeleteCourseAsync(id);
        }

    }
}
