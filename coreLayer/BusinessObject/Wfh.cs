using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreLayer.BusinessObject
{

    public partial class Wfh
    {
        public int id { get; set; }
        public int empId { get; set; }
        public string empname { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string reason { get; set; }
        public string Wfhstatus { get; set; }
        public int duration { get; set; }
        public IFormFile documents { get; set; }
        public string documentsName { get; set; }

        public Wfh()
        {
            id = 0;
            empId = 0;
            startDate = startDate;
            endDate = startDate;
            reason = "";
            Wfhstatus = "";
            duration = 0;
        }

        public Wfh(IDataReader reader)
        {
            id = Convert.ToInt32(reader["Id"]);

            duration = Convert.ToInt32(reader["Duration"]);
            startDate = Convert.ToDateTime(reader["StartDate"]);
            endDate = Convert.ToDateTime(reader["EndDate"]);
            reason = reader["Reason"].ToString();
            Wfhstatus = reader["Status"].ToString();
        }
    }
}
