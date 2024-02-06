using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Prodi is required")]
		public string Prodi { get; set; }
		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }

        // Navigation property to represent the many-to-many relationship
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
