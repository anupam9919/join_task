using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Web.Helpers;
using serviceLayer;
using task.AppCode;

namespace task.Pages.Leave
{
    [BindProperties]
    public class ApplyLeaveModel : PageModel
    {
        public int id { get; set; }

        public int empId { get; set; }
        //public int leaveCategoryId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string reason { get; set; }

        //public string status { get; set; }

        public bool isDocumentRequired { get; set; }
        //public string FileName { get; set; }
        // public string FilePath { get; set; }

        //public string leaveStatus { get; set; }
        //public List<string> LeaveStatus { get; private set; }

        public List<string> LeaveCategories { get; set; }

        public string LeaveCategory { get; set; }


        public string duration { get; set; }

        public IFormFile documents { get; set; }



        public string docs { get; set; }


        public void OnGet([FromQuery] int id)
        {

            LeaveCategories = CommonFunctions.GetLeaveName();

            this.id = id;
        }

        public IActionResult OnPost()
        {
            Leaves applyLeave = new Leaves();
            applyLeave.empId = id;
            applyLeave.startDate = startDate;
            applyLeave.endDate = endDate;
            applyLeave.reason = reason;


            applyLeave.duration = duration;
            applyLeave.docs = "docs";
            applyLeave.leaveName = LeaveCategory;

            // Handle document upload if required
            //LeaveCategoryInfo leaveCategory = LeaveCategories.Find(lc => lc.id == leaveCategoryId);
            //if (leaveCategory != null && leaveCategory.isDocumentRequired && documents != null && documents.Length > 0)
            //{
            //    applyLeave.documents = new FileUpload { FileName = documents.FileName };
            //}

            LeaveManager.AddLeave(applyLeave);

            return RedirectToPage("/Leave/listLeave");
        }




    }
}
