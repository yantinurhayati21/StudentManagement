using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDbContext _context;

        public CoursesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var result = await _context.Courses.ToListAsync();
            return result;
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var result = await _context.Courses.FindAsync(id);
            return result;
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<Course> UpdateAsync(int id, Course newCourse)
        {
            var existingCourse = await _context.Courses.FindAsync(id);

            if (existingCourse == null)
                return null;

            existingCourse.CourseName = newCourse.CourseName;

            _context.Update(existingCourse);
            await _context.SaveChangesAsync();

            return existingCourse;
        }

        public async Task DeleteAsync(int id)
        {
            var existingCourse = await _context.Courses.FindAsync(id);

            if (existingCourse == null)
                return;

            _context.Courses.Remove(existingCourse);
            await _context.SaveChangesAsync();
        }
    }
}
