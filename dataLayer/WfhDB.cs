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
    public class WfhDB
    {
        public static void AddWfh(Wfh wfh)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand($"INSERT INTO wfh(EmpId,StartDate, EndDate,Reason,Duration,WfhStatus) VALUES( @EmpId,@StartDate,@EndDate,@Reason,@Duration, @Wfhstatus); SELECT LAST_INSERT_ID()");


            db.AddInParameter(cmd, "@EmpId", DbType.Int32, wfh.empId);
            db.AddInParameter(cmd, "@StartDate", DbType.DateTime, wfh.startDate);
            db.AddInParameter(cmd, "@EndDate", DbType.DateTime, wfh.endDate);
            db.AddInParameter(cmd, "@Reason", DbType.String, wfh.reason);
            db.AddInParameter(cmd, "@Duration", DbType.Int32, wfh.duration);
            db.AddInParameter(cmd, "@Wfhstatus", DbType.String, wfh.Wfhstatus);

            wfh.id = int.Parse(db.ExecuteScalar(cmd).ToString());
        }

        public static void RemoveWfh(int id)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM wfh WHERE id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
        }
    }
}
