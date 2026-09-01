using AttendanceRecord.Models;

namespace AttendanceRecord.Models
{
    public class AttendVMcs
    {

        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
        public List<Attendance> attendances { get; set; }
        public List<Student> Student { get; set; }
        public int SubjectId { get; set; }
        public List<Subject> Subject { get; set; }

    }
}
