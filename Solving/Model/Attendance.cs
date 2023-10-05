using System.ComponentModel.DataAnnotations.Schema;

namespace Solving.Model
{
    public class Attendance
    {
        public int Id { get; set; }
      

        public DateTimeOffset attendanceDate { get; set; } = DateTimeOffset.UtcNow;
        public int isPresent { get; set; }
        public int isAbsent { get; set; }
        public int isOffday { get; set; }
        public int employeeId { get; set; }
     
    }
}
