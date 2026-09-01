using AttendanceRecord.Models;
using AttendanceRecord.Repo.Interface;
namespace AttendanceRecord.Repo
{
    public class ImStudent:IStudent
    {
        private readonly AppContexts contexts;
        public ImStudent(AppContexts contexts)
        {
            this.contexts = contexts;
        }
        public List<Student> GetAll()
        {
            return contexts.Students.ToList();  
        }
        public Student GetId(int id)
        {
            return contexts.Students.Find(id);
        }
        public void Delete(Student student)
        {
            contexts.Students.Remove(student);
            contexts.SaveChanges();
        }
        public void Update(Student student)
        {
            contexts.Students.Update(student);
            contexts.SaveChanges();

        }
        public void Add(Student student)
        {
            contexts.Students.Add(student);
            contexts.SaveChanges();

        }
    }
}
