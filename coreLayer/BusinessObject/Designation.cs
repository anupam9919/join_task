using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreLayer.BusinessObject
{
    public partial class Designation
    {
        public int id { get; set; }
        public string designationName { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Designation()
        {
            id = 0;
            designationName = "";
            createdBy = "";
            updatedBy = "";
            createdDate = createdDate;
            updatedDate = updatedDate;

        }

        public Designation(IDataReader reader)
        {
            id = Convert.ToInt32(reader["Id"]);
            designationName = reader["DesignationName"].ToString();
            createdBy = reader["CreatedBy"].ToString();
            updatedBy = reader["UpdatedBy"].ToString();
            createdDate = reader["CreatedOnUTC"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOnUTC"]);
            updatedDate = reader["UpdatedOnUTC"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["UpdatedOnUTC"]);
        }
    }
}
