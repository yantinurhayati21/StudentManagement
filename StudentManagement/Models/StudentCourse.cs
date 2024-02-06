namespace StudentManagement.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
