using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer
{
    public static class SLConstants
    {
        public static class Messages
        {
            public const string EmpSuccessMessage = "Employee Added Successfully";
            public const string EmpErrorMessage = "Employee Already Exists";
            public const string EmpUpdateSuccessMessage = "Employee Updated Successfully";
            public const string EmpUpdateErrorMessage = "Employee Already Exists";

            public const string DeptSuccessMessage = "Department Added Successfully";
            public const string DeptErrorMessage = "Department Already Exists";
            public const string DeptUpdateSuccessMessage = "Department Updated Successfully";
            public const string DeptUpdateErrorMessage = "Department Already Exists";
            public const string EmpErrorPhoneMessage = "Phone Number should be less than 10 digits";
            public const string EmpErrorNameMessage = "Employee with this name already exists";
            public const string EmpErrorEmailMessage = "Employee with this email already exists";

            public const string DeptErrorNameMessage = "Department with this name already exists";
        }
    }
}
