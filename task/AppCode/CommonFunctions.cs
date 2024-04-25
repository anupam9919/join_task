using coreLayer.BusinessObject;
using dataLayer;
using serviceLayer;

namespace task.AppCode
{
    public static class CommonFunctions
    {

        public static List<string> Status()
        {
            List<string> status = new List<string>();
            status.Add(Constants.Active);
            status.Add(Constants.Inactive);
            return status;
        }

        public static List<string> ApplyStatus()
        {
            List<string> leaveStatus = new List<string>();
            leaveStatus.Add(Constants.Approved);
            leaveStatus.Add(Constants.Pending);
            leaveStatus.Add(Constants.Rejected);
            return leaveStatus;
        }

        public static List<string> GetDepartmentsFromDatabase()
        {
            List<string> departments = new List<string>();

            foreach (var department in DepartmentDB.GetAll())
            {
                departments.Add(department.Name);
            }
            return departments;
        }

        public static List<string> GetDesignationsFromDatabase()
        {
            List<string> designations = new List<string>();

            foreach (var designation in DesignationDB.GetAll())
            {
                designations.Add(designation.designationName);
            }
            return designations;
        }

        public static List<LeaveCategoryInfo> GetLeaveCategoriesFromDatabase()
        {
            LeaveCategoryManager leaveCategoryManager = new LeaveCategoryManager();
            List<LeaveCategory> leaveCategories = leaveCategoryManager.GetAll();
            List<LeaveCategoryInfo> leaveCategoryInfos = new List<LeaveCategoryInfo>();

            foreach (LeaveCategory leaveCategory in leaveCategories)
            {
                leaveCategoryInfos.Add(new LeaveCategoryInfo
                {
                    id = leaveCategory.id,
                    name = leaveCategory.name,
                    isDocumentRequired = leaveCategory.isDocumentRequired
                });
            }

            return leaveCategoryInfos;
        }

        public static List<string> GetLeaveName()
        {
            List<string> leaveName = new List<string>();
            foreach (var leaveNames in LeaveCategoryDB.GetAll())
            {
                leaveName.Add(leaveNames.name);
            }
            return leaveName;
        }



    }

    public class LeaveCategoryInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isDocumentRequired { get; set; }
    }


}

