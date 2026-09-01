
using Microsoft.AspNetCore.Mvc;
using AttendanceRecord.Models;
using AttendanceRecord.Repo.Interface;
namespace AttendanceRecord.Controllers
{
    public class StudentController:Controller
    {
        private readonly IStudent student;
        public StudentController(IStudent student)
        {
            this.student = student;
        }
        public IActionResult Index()
        {
            var s = student.GetAll();
            return View(s);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student s)
        {
            student.Add(s);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var s=student.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            return View(s);
        }
        [HttpPost]
        public IActionResult Edit(Student s)
        {
            student.Update(s);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var s = student.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            student.Delete(s);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ViewList()
        {
            var s = student.GetAll();
            return View(s);
        }
    }
}
