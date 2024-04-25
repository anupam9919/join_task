using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;
using task.AppCode;

namespace task.Pages.WFH
{
    [BindProperties]
    public class ApplyWFHModel : PageModel
    {
        public string id { get; set; }
        public string empname { get; set; }

        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string reason { get; set; }
        public string Wfhstatus { get; set; }
        public int duration { get; set; }

        public List<string> applyStatus { get; set; }

        public IFormFile documents { get; set; }
        public string documentsName { get; set; }

        public void OnGet(int id)
        {
            applyStatus = CommonFunctions.ApplyStatus();

            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee = employeeManager.GetByID(id);
            id = employee.Id;
        }

        public IActionResult OnPost(int id)
        {
            Wfh wfh = new Wfh();
            wfh.empId = id;
            wfh.empname = empname;
            wfh.startDate = startDate;
            wfh.endDate = endDate;
            wfh.reason = reason;
            wfh.Wfhstatus = Wfhstatus;
            wfh.duration = duration;

            WfhManager wfhManager = new WfhManager();
            WfhManager.AddWfh(wfh);



            return RedirectToPage("/WFH/ListWFH");
        }
    }
}
