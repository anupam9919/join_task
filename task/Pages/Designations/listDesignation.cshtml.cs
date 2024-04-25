using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;

namespace task.Pages.Designations
{
    public class listDesignationModel : BaseModel
    {

        /// <summary>
        /// Gets or sets the list of departments.
        /// </summary>
        public List<Designation> DesignationList { get; set; }
        public string Message { get; set; }
        public int id { get; set; }


        /// <summary>
        /// Handles the HTTP GET request for the department list page.
        /// </summary>
        public void OnGet()
        {
            DesignationManager designationManager = new DesignationManager();
            log.Debug("Department List Page");
            DesignationList = designationManager.GetAll();
            log.Debug("Department List Page onGet Method Excecuted  ");

        }

        /// <summary>
        /// Handles the HTTP GET request for deleting a department.
        /// </summary>
        /// <param name="Id">The ID of the department to delete.</param>
        /// <returns>The IActionResult representing the result of the operation.</returns>
        public IActionResult OnGetDelete(int id)
        {
            log.Debug($"Department On Get Delete {id}");
            DesignationManager designationManager = new DesignationManager();
            designationManager.DeleteDesignation(id);
            log.Debug("Department Deleted");
            return RedirectToPage("/Designations/listDesignation");

        }
    }
}
