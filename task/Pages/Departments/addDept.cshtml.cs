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
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description of the department.
        /// <summary>
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(50)]
        public string Description { get; set; }


        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }


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
            Department department = new Department();
            department.Name = Name;
            department.Description = Description;
            department.CreatedBy = "System";
            department.UpdatedBy = "System";

            DepartmentManager departmentManager = new DepartmentManager();
            OperationResult operationResult = departmentManager.AddDepartment(department);
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
            log.Debug("Department Added");
        }
    }
}
