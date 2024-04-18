using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;

namespace task.Pages
{
    [BindProperties]
    public class empDataModel : PageModel
    {
        public List<Employee> Employeelist { get; set; }

        public void OnGet()
        {
            EmployeeManager employeeManager = new EmployeeManager();
            Employeelist = employeeManager.GetEmpData();
        }
    }
}
