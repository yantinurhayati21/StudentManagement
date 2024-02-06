using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Services;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _service;

        public CoursesController(ICoursesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var courseDetails = await _service.GetByIdAsync(id);

            if (courseDetails == null)
            {
                return View("NotFound");
            }

            return View(courseDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CourseName")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            await _service.AddAsync(course);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var courseDetails = await _service.GetByIdAsync(id);

            if (courseDetails == null)
            {
                return View("NotFound");
            }

            return View(courseDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, CourseName")] Course newCourse)
        {
            if (!ModelState.IsValid)
            {
                return View(newCourse);
            }

            var updatedCourse = await _service.UpdateAsync(id, newCourse);

            if (updatedCourse == null)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var courseDetails = await _service.GetByIdAsync(id);

            if (courseDetails == null)
            {
                return View("NotFound");
            }

            return View(courseDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseDetails = await _service.GetByIdAsync(id);

            if (courseDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
