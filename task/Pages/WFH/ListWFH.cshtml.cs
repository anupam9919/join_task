using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;

namespace task.Pages.WFH
{
    [BindProperties]
    public class ListWFHModel : PageModel
    {
        public List<Employee> EmployeeWfhList { get; set; }

        public void OnGet()
        {
            EmployeeManager employeeManager = new EmployeeManager();
            EmployeeWfhList = employeeManager.GetEmpWfh();
        }

        public IActionResult OnGetDelete(int id)
        {

            WfhManager wfhManager = new WfhManager();
            wfhManager.RemoveWfh(id);


            return RedirectToPage("/WFH/ListWFH");

        }
    }
}
