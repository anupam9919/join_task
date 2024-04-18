using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;

namespace task.Pages.Employees
{
    [BindProperties]
    public class empListModel : BaseModel
    {
        public List<Employee> Employeelist { get; set; }

        public string Message { get; set; }


        /// <summary>
        /// Handles the HTTP GET request for the employee list page.
        /// </summary>
        public void OnGet()
        {

            EmployeeManager employeeManager = new EmployeeManager();
            Employeelist = employeeManager.GetAll();
            log.Debug("Employee List Page onGet Method Excecuted  ");

        }

        /// <summary>
        /// Handles the HTTP GET request for deleting a employee.
        /// </summary>
        /// <param name="Id">The ID of the employee to delete.</param>
        /// <returns>The IActionResult representing the result of the operation.</returns>

        public IActionResult OnGetDelete(int Id)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            employeeManager.DeleteEmployee(Id);
            return RedirectToPage("/Employees/empList");
            log.Debug("Employee Deleted");
        }
    }
}
