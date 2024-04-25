using coreLayer;
using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;
using System.ComponentModel.DataAnnotations;
using static serviceLayer.SLConstants;

namespace task.Pages.Designations
{
    [BindProperties]

    public class updateDesignationModel : BaseModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string designationName { get; set; }

        public int id { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public void OnGet(int Id)
        {
            DesignationManager designationManager = new DesignationManager();
            Designation designation = designationManager.GetByID(Id);
            id = designation.id;
            designationName = designation.designationName;
            updatedBy = designation.updatedBy;
            updatedDate = designation.updatedDate;



        }

        public IActionResult OnPost()
        {
            Designation designation = new Designation();
            designation.id = id;
            designation.designationName = designationName;
            designation.updatedBy = "System";
            designation.updatedDate = DateTime.UtcNow;



            DesignationManager designationManager = new DesignationManager();

            OperationResult operationResult = designationManager.UpdateDesignation(designation);

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


        }
    }
}
