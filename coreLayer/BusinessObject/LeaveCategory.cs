using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreLayer.BusinessObject
{
    public partial class LeaveCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool isDocumentRequired { get; set; }

        public string createdBy { get; set; }

        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public DateTime createdDate { get; set; }

        public LeaveCategory()
        {
            id = 0;
            name = "";
            description = "";
            isDocumentRequired = false;
            createdBy = "";
            updatedBy = "";
            createdDate = createdDate;
            updatedDate = updatedDate;

        }

        public LeaveCategory(IDataReader reader)
        {
            id = Convert.ToInt32(reader["Id"]);
            name = reader["name"].ToString();
            description = reader["description"].ToString();
            isDocumentRequired = Convert.ToBoolean(reader["IsDocumentRequired"]);
            createdBy = reader["CreatedBy"].ToString();
            updatedBy = reader["UpdatedBy"].ToString();
            createdDate = reader["CreatedOnUTC"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedOnUTC"]);
            updatedDate = reader["UpdatedOnUTC"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["UpdatedOnUTC"]);
        }

    }
}
