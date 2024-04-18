using dataLayer;

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
        public static DateTime GetCurrentDateFormatted()
        {
            return DateTime.UtcNow;
        }
        public static List<string> GetDepartmentsFromDatabase()
        {
            List<string> departments = new List<string>();

            foreach (var department in DepartmentDB.GetAll() )
            {
                departments.Add(department.Name);
            }
            return departments;
        }

    }
}
