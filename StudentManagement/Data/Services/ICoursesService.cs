// ICoursesService.cs
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Services;
using StudentManagement.Models;

namespace StudentManagement.Data.Services
{
    public interface ICoursesService
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetByIdAsync(int id);
        Task AddAsync(Course course);
        Task<Course> UpdateAsync(int id, Course course);
        Task DeleteAsync(int id);
    }
}

