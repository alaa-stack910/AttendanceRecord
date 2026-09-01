
using AttendanceRecord.Models;
namespace AttendanceRecord.Repo.Interface
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public Student GetId(int id);
        public void Delete(Student student);
        public void Update(Student student);
        public void Add(Student student);
    }
}
