using AttendanceRecord.Models;
using AttendanceRecord.Repo.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceRecord.Controllers
{
    public class SubjectController:Controller
    {

        private readonly ISubject subject;
        private readonly AppContexts contexts;
        public SubjectController(ISubject subject, AppContexts contexts)
        {
            this.subject = subject;
            this.contexts = contexts;
        }
        public IActionResult Index()
        {
            var s = subject.GetAll();
            return View(s);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subject s)
        {
            subject.Add(s);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult ViewList()
        {
            var s = subject.GetAll();
            return View(s);
        }

        public IActionResult Search(string name)
        {
            var s = contexts.subjects.Where(h=>h.Name.Contains(name)).ToList();
            return View(s);
        }
    }
}
