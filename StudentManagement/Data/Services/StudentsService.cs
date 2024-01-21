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

        public Task AddAsync(Students students)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Students> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Students> UpdateAsync(int id, Students students)
        {
            throw new NotImplementedException();
        }
    }
}
