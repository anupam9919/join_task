using coreLayer.BusinessObject;
using coreLayer;
using dataLayer;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer
{
    public class LeaveCategoryManager
    {
        public static Logger log = LogManager.GetLogger("Service Layer");
        public OperationResult AddLeaveCategory(LeaveCategory leaveCategory)
        {
            LeaveCategory alreadyExistsByName = GetByName(leaveCategory.name);
            if (alreadyExistsByName != null)
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.LeaveCategoryErrorMessage, leaveCategory);
                log.Debug($"Designation Name:{leaveCategory.name} Already Exists");
            }

            LeaveCategoryDB.AddLeaveCategory(leaveCategory);
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.LeaveCategorySuccessMessage, leaveCategory);
            log.Debug($"Designation Name:{leaveCategory.name} Added");
        }


        public LeaveCategory GetByName(string name)
        {
            LeaveCategory leaveCategory = LeaveCategoryDB.GetByName(name);
            return leaveCategory;
        }


        public LeaveCategory GetByID(int id)
        {
            LeaveCategory leaveCategory = LeaveCategoryDB.GetByID(id);
            return leaveCategory;
        }

        public OperationResult UpdateLeaveCategory(LeaveCategory leaveCategory)
        {
            LeaveCategoryDB.UpdateLeaveCategory(leaveCategory);
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.LeaveUpdateSuccessMessage, leaveCategory);
            log.Debug($"Designation ID:{leaveCategory.id} Updated");
        }
        public void DeleteLeaveCategory(int id)
        {
            LeaveCategoryDB.DeleteLeaveCategory(id);
            log.Debug($"Designation ID:{id} Deleted");
        }


        public List<LeaveCategory> GetAll()
        {
            List<LeaveCategory> leaveCategoryList = LeaveCategoryDB.GetAll();
            log.Debug($"Designation List Returned");
            return leaveCategoryList;
        }
    }
}
