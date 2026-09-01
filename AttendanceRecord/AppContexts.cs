
using Microsoft.EntityFrameworkCore;
using AttendanceRecord.Models;
namespace AttendanceRecord
{
    public class AppContexts:DbContext
    {
        public AppContexts(DbContextOptions<AppContexts> Options) : base(Options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Attendance> attendances { get; set; }
    }
}
