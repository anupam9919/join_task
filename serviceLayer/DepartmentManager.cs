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
    public class DepartmentManager
    {
        public static Logger log = LogManager.GetLogger("Service Layer");
        public OperationResult AddDepartment(Department department)
        {
            Department alreadyExistsByName = GetByDeptName(department.Name);
            if (alreadyExistsByName != null)
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.DeptErrorMessage, department);
                log.Debug($"Department Name:{department.Name} Already Exists");
            }

            DepartmentDB.AddDepartment(department);
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.DeptSuccessMessage, department);
            log.Debug($"Department Name:{department.Name} Added");
        }

        public List<Department> GetAll()
        {
            List<Department> deptList = DepartmentDB.GetAll();
            log.Debug($"Department List Returned");
            return deptList;
        }

        public Department GetByDeptName(string Name)
        {
            Department department = DepartmentDB.GetByDeptName(Name);
            return department;
        }
        public Department GetByID(int Id)
        {
            Department department = DepartmentDB.GetByID(Id);
            return department;
        }

        public void UpdateDepartment(Department department)
        {
            DepartmentDB.UpdateDepartment(department);
            log.Debug($"Department ID:{department.Id} Updated");
        }
        public void DeleteDepartment(int Id)
        {
            DepartmentDB.DeleteDepartment(Id);
            log.Debug($"Department ID:{Id} Deleted");
        }
    }

}
