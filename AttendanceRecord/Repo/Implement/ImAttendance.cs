using AttendanceRecord.Models;
using AttendanceRecord.Repo.Interface;
using Microsoft.EntityFrameworkCore;
namespace AttendanceRecord.Repo.Implement
{
    public class ImAttendance:IAttendance
    {
  

        private readonly AppContexts contexts;
        public ImAttendance(AppContexts contexts)
        {
            this.contexts = contexts;
        }
        public List<Attendance> GetAll()
        {
            return contexts.attendances.Include(v=>v.Student).Include(c=>c.Subject).ToList();
        }
        public Attendance GetId(int id)
        {
            return contexts.attendances.Include(v => v.Student).Include(c => c.Subject).FirstOrDefault(v=>v.AttendanceId==id);
        }
        public void Delete(Attendance student)
        {
            contexts.attendances.Remove(student);
            contexts.SaveChanges();
        }
        public void Update(Attendance student)
        {
            contexts.attendances.Update(student);
            contexts.SaveChanges();

        }
        public void Add(Attendance student)
        {
            contexts.attendances.Add(student);
            contexts.SaveChanges();

        }
    }
}
