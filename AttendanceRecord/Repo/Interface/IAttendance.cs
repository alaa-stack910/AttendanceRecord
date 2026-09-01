using AttendanceRecord.Models;

namespace AttendanceRecord.Repo.Interface
{
    public interface IAttendance
    {


        public List<Attendance> GetAll();
        public Attendance GetId(int id);
        public void Delete(Attendance student);
        public void Update(Attendance student);
        public void Add(Attendance student);
    }
}
