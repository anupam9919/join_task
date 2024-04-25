using coreLayer.BusinessObject;
using coreLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;
using System.ComponentModel.DataAnnotations;

namespace task.Pages.Leave
{
    [BindProperties]
    public class addLeaveCategoryModel : BaseModel
    {
        // <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the Description of the department.
        /// <summary>
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(50)]
        public string description { get; set; }

        public bool isDocumentRequired { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }


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
            LeaveCategory leaveCategory = new LeaveCategory();
            leaveCategory.name = name;
            leaveCategory.description = description;
            leaveCategory.createdBy = "System";
            leaveCategory.updatedBy = "System";
            leaveCategory.createdDate = DateTime.UtcNow;
            leaveCategory.updatedDate = DateTime.UtcNow;
            leaveCategory.isDocumentRequired = isDocumentRequired;


            LeaveCategoryManager leaveCategoryManager = new LeaveCategoryManager();
            OperationResult operationResult = leaveCategoryManager.AddLeaveCategory(leaveCategory);
            if (operationResult.StatusCode == (int)OperationStatus.Success)
            {
                Success(operationResult.Message);
            }
            else
            {
                Warning(operationResult.Message);
                return Page();
            }
            return RedirectToPage("/Leave/listLeaveCategory");
            log.Debug("listLeaveCategory Added");
        }

    }
}
