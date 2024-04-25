using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreLayer.BusinessObject
{
    public partial class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }

        public string Designation { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string DepartmentDescription { get; set; }

        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string reason { get; set; }
        public string WfhStatus { get; set; }
        public int duration { get; set; }



        public Employee()
        {
            Id = 0;
            Name = "";
            Email = "";
            Phone = "";
            Department = "";
            Designation = "";
            Status = "";
            CreatedBy = "";
            UpdatedBy = "";
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
            DepartmentDescription = "";
            WfhStatus = "";
            startDate = DateTime.UtcNow;
            endDate = DateTime.UtcNow;
            reason = "";
            duration = 0;


        }
        public Employee(IDataReader reader)
        {
            Id = Convert.ToInt32(reader["Id"]);
            Name = reader["Name"].ToString();
            Email = reader["Email"].ToString();
            Phone = reader["Phone"].ToString();
            Department = reader["Department"].ToString();
            Designation = reader["Designation"].ToString();
            Status = reader["Status"].ToString();
            CreatedBy = reader["CreatedBy"].ToString();
            UpdatedBy = reader["UpdatedBy"].ToString();

            CreatedDate = Convert.ToDateTime(reader["CreatedOnUTC"]);
            UpdatedDate = Convert.ToDateTime(reader["UpdatedOnUTC"]);



        }


    }


}
