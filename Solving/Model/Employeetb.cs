using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solving.Model
{
    public class Employeetb
    {
        [Key]
        public int employeeId { get; set; }
        public string employeeName { get; set; }

        public string employeeCode { get; set; }
        public string employeeSalary { get; set; }
        public int supervisorId { get; set; }
     
    }
}
