using AttendanceRecord.Models;
using AttendanceRecord.Repo.Interface;

namespace AttendanceRecord.Repo.Implement
{
    public class ImSubject:ISubject
    {
  
        private readonly AppContexts contexts;
        public ImSubject(AppContexts contexts)
        {
            this.contexts = contexts;
        }
        public List<Subject> GetAll()
        {
            return contexts.subjects.ToList();
        }
        public Subject GetId(int id)
        {
            return contexts.subjects.Find(id);
        }
        public void Delete(Subject student)
        {
            contexts.subjects.Remove(student);
            contexts.SaveChanges();
        }
        public void Update(Subject student)
        {
            contexts.subjects.Update(student);
            contexts.SaveChanges();

        }
        public void Add(Subject student)
        {
            contexts.subjects.Add(student);
            contexts.SaveChanges();

        }
    }
}
