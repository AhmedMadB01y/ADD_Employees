using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public enum Gender
    {

        Male, Female
    }
    public class Employee
    {

        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? JobRole { get; set; }
        public Gender? Gender { get; set; }
        public Boolean FirstAppointment { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public string? Notes { get; set; }
    }


}
