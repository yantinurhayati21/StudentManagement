using StudentManagement.Models;

namespace StudentManagement.Data.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Students>> GetAll();
        Task<Students> GetByIdAsync(int id);
        Task AddAsync(Students students);
        Task<Students> UpdateAsync(int id,Students students);
        Task DeleteAsync(int id);
    }
}
