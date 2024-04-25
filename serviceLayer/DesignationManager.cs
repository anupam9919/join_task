using coreLayer;
using coreLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using System.Text;
using System.Threading.Tasks;
using dataLayer;

namespace serviceLayer
{
    public class DesignationManager
    {
        public static Logger log = LogManager.GetLogger("Service Layer");
        public OperationResult AddDesignation(Designation designation)
        {
            Designation alreadyExistsByName = GetByDesignationName(designation.designationName);
            if (alreadyExistsByName != null)
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.DesignationErrorNameMessage, designation);
                log.Debug($"Designation Name:{designation.designationName} Already Exists");
            }

            DesignationDB.AddDesignation(designation);
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.DesignationSuccessMessage, designation);
            log.Debug($"Designation Name:{designation.designationName} Added");
        }

        public List<Designation> GetAll()
        {
            List<Designation> designationList = DesignationDB.GetAll();
            log.Debug($"Designation List Returned");
            return designationList;
        }

        public Designation GetByDesignationName(string designationName)
        {
            Designation designation = DesignationDB.GetByDesignationName(designationName);
            return designation;
        }
        public Designation GetByID(int id)
        {
            Designation designation = DesignationDB.GetByID(id);
            return designation;
        }

        public OperationResult UpdateDesignation(Designation designation)
        {
            DesignationDB.UpdateDesignation(designation);
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.DesignationUpdateSuccessMessage, designation);
            log.Debug($"Designation ID:{designation.id} Updated");
        }
        public void DeleteDesignation(int id)
        {
            DesignationDB.DeleteDesignation(id);
            log.Debug($"Designation ID:{id} Deleted");
        }
    }
}
