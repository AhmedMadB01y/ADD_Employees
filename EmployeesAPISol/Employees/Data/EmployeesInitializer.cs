using Employees.Models;

namespace Employees.Data
{
    public static class EmployeesInitializer
    {
        public static void Initialize(EmployeesDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Employees.Any())
            {
                return;
            }



            var employees = new Employee[] {
        new Employee {EmployeeName = "Ahmed Nady" , JobRole = "Front End Developer" , Gender = Gender.Male, FirstAppointment = true , StartDate = DateTime.Parse("1/5/1995") , Notes = ""},
        new Employee {EmployeeName = "Sami Refaat" , JobRole = "Back End Developer" , Gender = Gender.Male, FirstAppointment = true , StartDate = DateTime.Parse  ("3/6/1997") , Notes = ""},
        new Employee {EmployeeName = "Fady Khaled" , JobRole = "UI/UX" ,  Gender =Gender.Male , FirstAppointment = false , StartDate = DateTime.Parse ("5/7/1999") , Notes = ""},
        new Employee {EmployeeName = "Mohamed Kamal" , JobRole = "Mobile App" , Gender = Gender.Male, FirstAppointment = false , StartDate = DateTime.Parse("4/8/1993") , Notes = ""},
        new Employee {EmployeeName = "Mostafa Ahmed" , JobRole = "Web App" , Gender = Gender.Male , FirstAppointment = false , StartDate = DateTime.Parse("7/9/2001") , Notes = ""},
        };

            foreach (var employee in employees) { context.Employees.Add(employee); }
            context.SaveChanges();
        }
    }
}
