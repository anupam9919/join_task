using coreLayer.BusinessObject;
using dataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceLayer;
using System.ComponentModel.DataAnnotations;
using task.AppCode;

namespace task.Pages.Employees
{
    [BindProperties]
    public class updateEmpModel : BaseModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Select Department")]

        public string Department { get; set; }
        [Required(ErrorMessage = "Please Select Status")]
        public string Status { get; set; }

        public List<string> Departments { get; set; }
        [Required(ErrorMessage = "Please Select Status")]
        public List<string> Statuses { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        public void OnGet(int ID)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee = employeeManager.GetByID(ID);

            Name = employee.Name;
            Email = employee.Email;
            Phone = employee.Phone;
            Department = employee.Department;
            Status = employee.Status;

            Statuses = CommonFunctions.Status();

            Departments = CommonFunctions.GetDepartmentsFromDatabase();
        }
        public IActionResult OnPost()
        {
            Employee employee = new Employee();
            employee.Id = Id;
            employee.Name = Name;
            employee.Email = Email;
            employee.Phone = Phone;
            employee.Department = Department;
            employee.Status = Status;
            employee.UpdatedBy = "System";
            //employee.UpdatedDate = UpdatedDate;

            EmployeeManager employeeManager = new EmployeeManager();
            employeeManager.UpdateEmployee(employee);

            if (employee.Id != default(int))
            {
                Success(Messages.EmpUpdateSuccessMessage);
            }
            else
            {
                Warning(Messages.EmpUpdateErrorMessage);
            }

            return RedirectToPage("/Employees/empList");

        }

    }
}
