using coreLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;
using Renci.SshNet.Messages;
using serviceLayer;

namespace task.Pages.Departments
{
    [BindProperties]
    public class deptListModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the list of departments.
        /// </summary>
        public List<Department> DepartmentList { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }


        /// <summary>
        /// Handles the HTTP GET request for the department list page.
        /// </summary>
        public void OnGet()
        {
            DepartmentManager departmentManager = new DepartmentManager();
            log.Debug("Department List Page");
            DepartmentList = departmentManager.GetAll();
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
            DepartmentManager departmentManager = new DepartmentManager();
            departmentManager.DeleteDepartment(Id);
            log.Debug("Department Deleted");
            return RedirectToPage("/Departments/deptList");

        }
    }
}
