namespace AttendanceRecord.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

    }
}
