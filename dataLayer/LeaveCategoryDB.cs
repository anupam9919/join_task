using coreLayer;
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
    public class LeaveCategoryDB
    {
        public static void AddLeaveCategory(LeaveCategory leaveCategory)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand($"INSERT INTO LeaveCategory(Name,Description, isDocumentRequired, CreatedBy, UpdatedBy, CreatedOnUTC, UpdatedOnUTC) VALUES(@Name,@Description,@isDocumentRequired, @createdBy, @updatedBy , @createdDate, @updatedDate); SELECT LAST_INSERT_ID()");
            db.AddInParameter(cmd, "Name", DbType.String, leaveCategory.name);
            db.AddInParameter(cmd, "Description", DbType.String, leaveCategory.description);
            db.AddInParameter(cmd, "isDocumentRequired", DbType.Boolean, leaveCategory.isDocumentRequired);

            db.AddInParameter(cmd, "createdBy", DbType.String, leaveCategory.createdBy);
            db.AddInParameter(cmd, "updatedBy", DbType.String, leaveCategory.updatedBy);
            db.AddInParameter(cmd, "createdDate", DbType.DateTime, leaveCategory.createdDate);
            db.AddInParameter(cmd, "updatedDate", DbType.DateTime, leaveCategory.updatedDate);

            leaveCategory.id = int.Parse(db.ExecuteScalar(cmd).ToString());
        }

        public static LeaveCategory GetByName(string name)
        {
            LeaveCategory leaveCategory = null;
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM LeaveCategory WHERE Name=@Name");
            db.AddInParameter(cmd, "Name", DbType.String, name);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                leaveCategory = new LeaveCategory(reader);
            }
            return leaveCategory;
        }



        public static void DeleteLeaveCategory(int id)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM LeaveCategory WHERE Id=@id");
            db.AddInParameter(cmd, "Id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);

        }

        public static List<LeaveCategory> GetAll()
        {
            List<LeaveCategory> leaveCategoryList = new List<LeaveCategory>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM LeaveCategory");
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                LeaveCategory leaveCategory = new LeaveCategory(reader);
                leaveCategoryList.Add(leaveCategory);
            }
            return leaveCategoryList;
        }



        public static LeaveCategory GetByID(int id)
        {
            LeaveCategory leaveCategory = new LeaveCategory();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM LeaveCategory WHERE Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);

            if (reader.Read())
            {
                leaveCategory = new LeaveCategory(reader);
            }

            return leaveCategory;
        }

        public static void UpdateLeaveCategory(LeaveCategory leaveCategory)
        {

            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("UPDATE LeaveCategory SET  Name=@name, Description=@description,UpdatedBy=@updatedBy, UpdatedOnUTC=@updatedDate, isDocumentRequired=@isDocumentRequired  WHERE Id=@id");
            db.AddInParameter(cmd, "name", DbType.String, leaveCategory.name);
            db.AddInParameter(cmd, "description", DbType.String, leaveCategory.description);
            db.AddInParameter(cmd, "isDocumentRequired", DbType.Boolean, leaveCategory.isDocumentRequired);
            db.AddInParameter(cmd, "updatedBy", DbType.String, leaveCategory.updatedBy);
            db.AddInParameter(cmd, "updatedDate", DbType.DateTime, leaveCategory.updatedDate);
            db.AddInParameter(cmd, "id", DbType.Int32, leaveCategory.id);

            db.ExecuteNonQuery(cmd);
        }

    }
}
