using coreLayer;
using coreLayer.BusinessObject;
using dataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;
using System.ComponentModel.DataAnnotations;
using static serviceLayer.SLConstants;

namespace task.Pages.Leave
{
    [BindProperties]
    public class updateLeaveCategoryModel : BaseModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string name { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(50)]
        public string description { get; set; }

        public bool isDocumentRequired { get; set; }
        public int id { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public void OnGet(int id)
        {
            LeaveCategoryManager leaveCategoryManager = new LeaveCategoryManager();
            LeaveCategory leaveCategory = leaveCategoryManager.GetByID(id);
            id = leaveCategory.id;
            name = leaveCategory.name;
            description = leaveCategory.description;
            isDocumentRequired = leaveCategory.isDocumentRequired;
            updatedBy = leaveCategory.updatedBy;
            updatedDate = leaveCategory.updatedDate;
        }

        public IActionResult OnPost(int id)
        {
            LeaveCategory leaveCategory = new LeaveCategory();
            leaveCategory.id = id;
            leaveCategory.name = name;
            leaveCategory.description = description;
            leaveCategory.isDocumentRequired = isDocumentRequired;
            leaveCategory.updatedBy = "System";
            leaveCategory.updatedDate = DateTime.UtcNow;

            LeaveCategoryManager leaveCategoryManager = new LeaveCategoryManager();
            OperationResult operationResult = leaveCategoryManager.UpdateLeaveCategory(leaveCategory);

            if (operationResult.StatusCode == (int)OperationStatus.Success)
            {
                Success(Messages.EmpUpdateSuccessMessage);
            }
            else
            {
                Warning(Messages.EmpUpdateErrorMessage);
                return Page();
            }

            return RedirectToPage("/Leave/listLeaveCategory");



        }

    }
}
