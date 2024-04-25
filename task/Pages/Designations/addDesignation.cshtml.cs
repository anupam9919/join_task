using coreLayer.BusinessObject;
using coreLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;
using System.ComponentModel.DataAnnotations;

namespace task.Pages.Designations
{
    [BindProperties]
    public class addDesignationModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Designation")]
        [StringLength(50)]

        public string designationName { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        /// <summary>
        /// Handles the HTTP GET request for the add department page.
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Handles the HTTP POST request for adding a department.
        /// </summary>
        /// <returns>The IActionResult representing the result of the operation.</returns>

        public IActionResult OnPost()
        {
            Designation designation = new Designation();
            designation.designationName = designationName;
            designation.createdBy = "System";
            designation.updatedBy = "System";
            designation.createdDate = DateTime.UtcNow;
            designation.updatedDate = DateTime.UtcNow;


            DesignationManager designationManager = new DesignationManager();
            OperationResult operationResult = designationManager.AddDesignation(designation);
            if (operationResult.StatusCode == (int)OperationStatus.Success)
            {
                Success(operationResult.Message);
            }
            else
            {
                Warning(operationResult.Message);
                return Page();
            }
            return RedirectToPage("/Designations/listDesignation");
            log.Debug("Designation Added");
        }
    }
}
