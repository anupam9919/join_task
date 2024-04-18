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
        
        public List<Department> DepartmentList { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public void OnGet()
        { 
            DepartmentManager departmentManager = new DepartmentManager();
            log.Debug("Department List Page");
            DepartmentList = departmentManager.GetAll();
            log.Debug("Department List Page onGet Method Excecuted  ");

        }

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
