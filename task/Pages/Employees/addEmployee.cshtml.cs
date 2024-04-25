using coreLayer;
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
    public class addEmployeeModel : BaseModel
    {
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
        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public List<string> Designations { get; set; }

        public string Designation { get; set; }





        /// <summary>
        /// Handles the HTTP GET request for the add employee page.
        /// </summary>
        public void OnGet()
        {
            Statuses = CommonFunctions.Status();
            Departments = CommonFunctions.GetDepartmentsFromDatabase();
            Designations = CommonFunctions.GetDesignationsFromDatabase();


        }

        /// <summary>
        /// Handles the HTTP POST request for adding a employee.
        /// </summary>
        /// <returns>The IActionResult representing the result of the operation.</returns>

        public IActionResult OnPost()
        {
            Employee employee = new Employee();
            employee.Name = Name;
            employee.Email = Email;
            employee.Phone = Phone;
            employee.Department = Department;
            employee.Designation = Designation;
            employee.Status = Status;
            employee.CreatedBy = "System";
            employee.UpdatedBy = "System";


            EmployeeManager employeeManager = new EmployeeManager();
            OperationResult operationResult = employeeManager.AddEmployee(employee);
            if (operationResult.StatusCode == (int)OperationStatus.Success)
            {
                Success(operationResult.Message);
            }
            else
            {
                Warning(operationResult.Message);
                Departments = CommonFunctions.GetDepartmentsFromDatabase();
                Statuses = CommonFunctions.Status();
                Designations = CommonFunctions.GetDesignationsFromDatabase();
                return Page();
            }


            return RedirectToPage("/Employees/empList");
        }
    }
}
