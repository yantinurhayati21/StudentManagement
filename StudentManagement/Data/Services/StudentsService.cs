using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly AppDbContext _context;

        public StudentsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Students>> GetAll()
        {
            var result = await _context.Students.ToListAsync();
            return result;
        }

        public async Task AddAsync(Students students)
        {
            await _context.Students.AddAsync(students);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            _context.Students.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Students> GetByIdAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Students> UpdateAsync(int id, Students newStudent)
        {
            _context.Update(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
           
        }
    }
}
