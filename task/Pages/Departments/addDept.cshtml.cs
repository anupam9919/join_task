using coreLayer;
using coreLayer.BusinessObject;
using dataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;
using System.ComponentModel.DataAnnotations;
using task.AppCode;

namespace task.Pages.Departments
{
    [BindProperties]
    public class addDeptModel : BaseModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(50)]
        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Department department = new Department();
            department.Name = Name;
            department.Description = Description;
            department.CreatedBy = "System";
            department.UpdatedBy = "System";

            DepartmentManager departmentManager = new DepartmentManager();
            OperationResult operationResult= departmentManager.AddDepartment(department);
            if (operationResult.StatusCode == (int)OperationStatus.Success)
            {
                Success(operationResult.Message);
            }
            else
            {
                Warning(operationResult.Message);
                return Page();
            }
            return RedirectToPage("/Departments/deptList");
        }
    }
}
