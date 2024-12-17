using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bysprojee.Model
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Course_ID { get; set; }
        [Required]
        public string Course_Name { get; set; }
        public int Credits { get; set; }
        [ForeignKey("Instructor")]
        public int Instructor_ID { get; set; }

        public Instructor Instructor { get; set; }

    }
}
