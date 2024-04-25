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
            public const string EmpErrorPhoneMessage = "Phone Number should be less than 10 digits";
            public const string EmpErrorNameMessage = "Employee with this name already exists";
            public const string EmpErrorEmailMessage = "Employee with this email already exists";


            public const string DeptSuccessMessage = "Department Added Successfully";
            public const string DeptErrorMessage = "Department Already Exists";
            public const string DeptUpdateSuccessMessage = "Department Updated Successfully";
            public const string DeptUpdateErrorMessage = "Department Already Exists";


            public const string DesignationErrorNameMessage = "Designation with this name already exists";
            public const string DesignationSuccessMessage = "Designation Added Successfully";
            public const string DesignationUpdateSuccessMessage = "Designation Updated Successfully";
            public const string DesignationUpdateErrorMessage = "Designation Already Exists";


            public const string LeaveSuccessMessage = "Leave Added Successfully";
            public const string LeaveErrorMessage = "Leave Already Exists";
            public const string LeaveUpdateSuccessMessage = "Leave Updated Successfully";
            public const string LeaveUpdateErrorMessage = "Leave Already Exists";


            public const string LeaveCategorySuccessMessage = "Leave Category Added Successfully";
            public const string LeaveCategoryErrorMessage = "Leave Category Already Exists";
            public const string LeaveCategoryUpdateSuccessMessage = "Leave Category Updated Successfully";
            public const string LeaveCategoryUpdateErrorMessage = "Leave Category Already Exists";

        }
    }
}
