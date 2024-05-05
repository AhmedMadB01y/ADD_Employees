using System.ComponentModel.DataAnnotations;

namespace EmployeesWeb.Models
{

    public enum Gender
    {

        Male, Female
    }
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Employee Name is Required.")]
        [Display(Name ="Employee Name")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Please Choose the Job role.")]
        [Display(Name = "Job Role")]
        public string? JobRole { get; set; }

        public Gender? Gender { get; set; }

        [Display(Name = "First Appointment")]
        public Boolean FirstAppointment { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public string? Notes { get; set; }
    }
}
