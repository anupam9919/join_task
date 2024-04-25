using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreLayer.BusinessObject
{
    public partial class Leaves
    {
        public int id { get; set; }
        public int empId { get; set; }
        //public string FileName { get; set; }
        //public string FilePath { get; set; }
        // public FileUpload documents { get; set; }
        //public string empname { get; set; }
        public int leaveCategoryId { get; set; }

        public string leaveName { get; set; }
        public DateTime startDate { get; set; }
        public string duration { get; set; }
        public DateTime endDate { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public string docs { get; set; }

        public string documents { get; set; }

        public Leaves()
        {
            id = 0;
            empId = 0;
            leaveCategoryId = 0;
            duration = "";

            startDate = DateTime.UtcNow;
            endDate = DateTime.UtcNow;
            reason = "";
            status = "";
            docs = "";
            leaveName = "";
        }


        public Leaves(IDataReader reader)
        {
            id = Convert.ToInt32(reader["Id"]);
            duration = reader["Duration"].ToString();
            startDate = Convert.ToDateTime(reader["StartDate"]);
            endDate = Convert.ToDateTime(reader["EndDate"]);
            reason = reader["Reason"].ToString();
            status = reader["Status"].ToString();
            leaveName = reader["LeaveName"].ToString();


        }

    }


}
