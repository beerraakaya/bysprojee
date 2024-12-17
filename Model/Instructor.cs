using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bysprojee.Model
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Instructor_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string First_Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Last_Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Department { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
