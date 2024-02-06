using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        // Navigation property to represent the many-to-many relationship
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
