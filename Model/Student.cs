using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bysprojee.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Student_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string First_Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Last_Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Username{ get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

        public List<Course> CoursesSelected { get; set; } = new List<Course>();


    }
}
