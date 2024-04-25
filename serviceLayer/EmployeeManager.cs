using coreLayer;
using coreLayer.BusinessObject;
using dataLayer;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer
{
    public class EmployeeManager
    {
        public static Logger log = LogManager.GetLogger("Service Layer");
        public OperationResult AddEmployee(Employee employee)
        {
            Employee alreadyExistsByName = GetByName(employee.Name);
            if (alreadyExistsByName != null)
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.EmpErrorNameMessage, employee);
                log.Debug($"Employee Name:{employee.Name} Already Exists");
            }

            if (employee.Phone.Length > 10)
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.EmpErrorPhoneMessage, employee);
                log.Debug($"Employee Phone:{employee.Phone} is more than 10 digits");
            }

            Employee alreadyExists = GetByEmail(employee.Email);
            if (alreadyExists != null)
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.EmpErrorEmailMessage, employee);
                log.Debug($"Employee Email:{employee.Email} Already Exists");
            }


            EmployeeDB.AddEmployee(employee);
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.EmpSuccessMessage, employee);
            log.Debug($"Employee Name:{employee.Name} Added");
        }
        public void UpdateEmployee(Employee employee)
        {
            EmployeeDB.UpdateEmployee(employee);
            log.Debug($"Employee ID:{employee.Id} Updated");
        }
        public void DeleteEmployee(int Id)
        {
            EmployeeDB.DeleteEmployee(Id);
            log.Debug($"Employee ID:{Id} Deleted");
        }

        public Employee GetByEmail(string Email)
        {
            Employee employee = EmployeeDB.GetByEmail(Email);


            return employee;
        }
        public Employee GetByName(string Name)
        {
            Employee employee = EmployeeDB.GetByName(Name);

            return employee;
        }
        public List<Employee> GetAll()
        {
            List<Employee> employeeList = EmployeeDB.GetAll();
            log.Debug($"All Employees Found");
            return employeeList;
        }


        public Employee GetByID(int Id)
        {
            Employee employee = EmployeeDB.GetByID(Id);
            return employee;
        }

        public List<Employee> GetEmpData()
        {
            List<Employee> employeeList = EmployeeDB.GetEmpData();
            log.Debug($"All Employees and their Departments Found");
            return employeeList;

        }

        public List<Employee> GetEmpWfh()
        {
            List<Employee> employeeWfhList = EmployeeDB.GetEmpWfh();
            log.Debug($"All Employees and their Departments Found");
            return employeeWfhList;

        }


    }
}

