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
    public class updateDeptModel : BaseModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(50)]
        public string Description { get; set; }
        public int Id { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public void OnGet(int Id)
        {
            DepartmentManager departmentManager = new DepartmentManager();
            Department department = departmentManager.GetByID(Id);

            Name = department.Name;
            Description = department.Description;
            UpdatedDate = DateTime.Now;


        }

        public IActionResult OnPost()
        {
            Department department = new Department();
            department.Id = Id;
            department.Name = Name;
            department.Description = Description;
            department.UpdatedBy = "System";
            

            DepartmentManager departmentManager = new DepartmentManager();
            departmentManager.UpdateDepartment(department);

            if (department.Id != default(int))
            {
                Success(Messages.DeptUpdateSuccessMessage);
            }
            else
            {
                Warning(Messages.DeptUpdateErrorMessage);
            }

            return RedirectToPage("/Departments/deptList");

        }
    }
}
