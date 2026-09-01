using AttendanceRecord.Models;

namespace AttendanceRecord.Repo.Interface
{
    public interface ISubject
    {
 
        public List<Subject> GetAll();
        public Subject GetId(int id);
        public void Delete(Subject student);
        public void Update(Subject student);
        public void Add(Subject student);
    }
}
