using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreLayer.BusinessObject
{
    public partial class Department
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }




        public Department()
        {
            Id = 0;
            Name = "";
            Description = "";
            CreatedBy = "";
            UpdatedBy = "";
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;

        }
        public Department(IDataReader reader)
        {   
            Id = Convert.ToInt32(reader["Id"]);
            Name = reader["Name"].ToString();
            Description = reader["Description"].ToString();
            CreatedBy = reader["CreatedBy"].ToString();
            UpdatedBy = reader["UpdatedBy"].ToString();
            CreatedDate = Convert.ToDateTime(reader["CreatedOnUTC"]);
            UpdatedDate = Convert.ToDateTime(reader["UpdatedOnUTC"]);




        }
    }
}
