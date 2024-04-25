using coreLayer.BusinessObject;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataLayer
{
    public class LeaveDB
    {
        public static void AddLeave(Leaves leave)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand($"INSERT INTO leaves(StartDate, EndDate, Reason, Duration, Document,LeaveName,EmpId ) VALUES(@startDate, @endDate, @reason,@duration, @document,@leaveName,@empId )");

            db.AddInParameter(cmd, "empId", DbType.Int32, leave.empId);
            db.AddInParameter(cmd, "startDate", DbType.DateTime, leave.startDate);
            db.AddInParameter(cmd, "endDate", DbType.DateTime, leave.endDate);
            db.AddInParameter(cmd, "reason", DbType.String, leave.reason);
            db.AddInParameter(cmd, "duration", DbType.String, leave.duration);
            db.AddInParameter(cmd, "leaveName", DbType.String, leave.leaveName);
            db.AddInParameter(cmd, "document", DbType.String, leave.docs);

            db.ExecuteNonQuery(cmd);
            //leave.id = int.Parse(db.ExecuteScalar(cmd).ToString());
        }
    }
}
