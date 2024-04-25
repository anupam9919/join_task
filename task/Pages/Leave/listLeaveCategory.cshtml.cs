using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;

namespace task.Pages.Leave
{
    public class listLeaveCategoryModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the list of departments.
        /// </summary>
        public List<LeaveCategory> LeaveCategoryList { get; set; }
        public string Message { get; set; }
        public int id { get; set; }


        /// <summary>
        /// Handles the HTTP GET request for the department list page.
        /// </summary>
        public void OnGet()
        {
            LeaveCategoryManager leaveCategoryManager = new LeaveCategoryManager();
            log.Debug("Department List Page");
            LeaveCategoryList = leaveCategoryManager.GetAll();
            log.Debug("Department List Page onGet Method Excecuted  ");

        }

        /// <summary>
        /// Handles the HTTP GET request for deleting a department.
        /// </summary>
        /// <param name="Id">The ID of the department to delete.</param>
        /// <returns>The IActionResult representing the result of the operation.</returns>
        public IActionResult OnGetDelete(int Id)
        {
            log.Debug($"Department On Get Delete {Id}");
            LeaveCategoryManager leaveCategoryManager = new LeaveCategoryManager();
            leaveCategoryManager.DeleteLeaveCategory(Id);
            log.Debug("Department Deleted");
            return RedirectToPage("/Leave/listLeaveCategory");

        }


    }
}
