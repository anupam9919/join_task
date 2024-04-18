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
        public void OnGet()
        {

            EmployeeManager employeeManager = new EmployeeManager();
            Employeelist = employeeManager.GetAll();
             
        }

        public IActionResult OnGetDelete(int Id)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            employeeManager.DeleteEmployee(Id);
            return RedirectToPage("/Employees/empList");
        }
    }
}
