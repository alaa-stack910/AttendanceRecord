using AttendanceRecord.Models;
using AttendanceRecord.Repo.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AttendanceRecord.Controllers
{
    public class AttendanceController:Controller
    {
 
        private readonly IStudent student;
        private readonly ISubject subject;
        private readonly IAttendance attendance;
        private readonly AppContexts appContexts;


        public AttendanceController(IStudent student, ISubject subject, IAttendance attendance, AppContexts appContexts)

        {
            this.student = student;
            this.subject = subject;
            this.attendance = attendance;
            this.appContexts = appContexts; 
        }
        public IActionResult Index()
        {
            var s = attendance.GetAll();
            return View(s);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new AttendVMcs
            {
                Student = student.GetAll(),
                Subject = subject.GetAll(),

            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(AttendVMcs s)
        {
            var a = new Attendance
            {
                AttendanceId = s.AttendanceId,
                SubjectId = s.SubjectId,
                StudentId = s.StudentId,
                Date = s.Date,
                Status = s.Status
            };

            

            attendance.Add(a);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var s = attendance.GetId(id);
            if (s == null)
            {
                return NotFound();
            }

            var a = new AttendVMcs
            {
                AttendanceId = s.AttendanceId,
                Date = s.Date,
                Status = s.Status,
                StudentId = s.StudentId,
                SubjectId = s.SubjectId,
                Subject = subject.GetAll(),
                Student = student.GetAll()

            };
            return View(a);
        }
        [HttpPost]
        public IActionResult Edit(AttendVMcs v)
        {
            var s = attendance.GetId(v.AttendanceId);
            if (s == null)
            {
                return NotFound();
            }
            s.AttendanceId=v.AttendanceId;
            s.StudentId=v.StudentId;
            s.SubjectId=v.SubjectId;
            s.Status=v.Status;
            s.Date=v.Date;
            attendance.Update(s);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var s = attendance.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            attendance.Delete(s);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ViewList()
        {
            var s = attendance.GetAll();
            return View(s);
        }


        public IActionResult Filter(int ? StudentId,int ? SubjectId )
        {
            var attend = appContexts.attendances.Include(s => s.Subject).Include(s => s.Student).AsQueryable();

            if (StudentId != null)
            {
                attend=attend.Where(s=>s.StudentId==StudentId);
            }
            if (SubjectId != null)
            {
                attend = attend.Where(s => s.SubjectId == SubjectId);
            }

            var v = new AttendVMcs
            {
                StudentId = StudentId ?? 0,
                SubjectId = SubjectId ?? 0,
                Student = student.GetAll(),
                Subject = subject.GetAll(),
                attendances = attend.ToList()
            };

            return View(v);
        }
    }
}
