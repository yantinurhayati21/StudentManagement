using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Services;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _service;

        public StudentsController(IStudentsService service)
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
            var studentsDetails = await _service.GetByIdAsync(id);
            if(studentsDetails == null)
            {
                return View("NotFound");
            }
            return View(studentsDetails);  
        }

        //Get : /Students/Create
        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
        //Bind artinya menentukan etribut apa saja yang akan di tambah
        public async Task<IActionResult> Create([Bind("Name,Prodi,Address")] Students student)
        {
            if(!ModelState.IsValid)
            {
                return View(student);
            }
            await _service.AddAsync(student);
            return RedirectToAction(nameof(Index));
        }

        //Get : /Students/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var studentsDetails = await _service.GetByIdAsync(id);

            if(studentsDetails == null) return View("NotFounds");
            return View(studentsDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Prodi,Address")] Students newStudent)
        {
            if(!ModelState.IsValid)
            {
                return View(newStudent);
            }
            await _service.UpdateAsync(id, newStudent);
            return RedirectToAction(nameof(Index));
        }

        //Get : /Students/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var studentsDetails = await _service.GetByIdAsync(id);
            if(studentsDetails == null) return View("NotFound");
            return View(studentsDetails);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentDetails = await _service.GetByIdAsync(id);
            if(studentDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}