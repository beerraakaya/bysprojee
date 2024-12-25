namespace bysprojee.Model
{
    public class StudentCourse
    {
        public int Student_ID { get; set; }
        public Student Student { get; set; }

        public int Course_ID { get; set; }
        public Course Course { get; set; }
    }
}
