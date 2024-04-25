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
    public class DesignationDB
    {
        public static void AddDesignation(Designation designation)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand($"INSERT INTO Designation(DesignationName, createdBy, updatedBy, CreatedOnUTC, UpdatedOnUTC) VALUES(@DesignationName, @CreatedBy, @UpdatedBy , @createdDate, @updatedDate); SELECT LAST_INSERT_ID()");
            db.AddInParameter(cmd, "designationName", DbType.String, designation.designationName);
            db.AddInParameter(cmd, "createdBy", DbType.String, designation.createdBy);
            db.AddInParameter(cmd, "updatedBy", DbType.String, designation.updatedBy);
            db.AddInParameter(cmd, "createdDate", DbType.DateTime, designation.createdDate);
            db.AddInParameter(cmd, "updatedDate", DbType.DateTime, designation.updatedDate);

            designation.id = int.Parse(db.ExecuteScalar(cmd).ToString());
        }

        public static void DeleteDesignation(int id)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM Designation WHERE Id=@id");
            db.AddInParameter(cmd, "Id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);

        }

        public static List<Designation> GetAll()
        {
            List<Designation> designationList = new List<Designation>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Designation");
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                Designation designation = new Designation(reader);
                designationList.Add(designation);
            }
            //
            return designationList;
        }



        public static Designation GetByID(int id)
        {
            Designation designation = null;
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Designation WHERE Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);

            if (reader.Read())
            {
                designation = new Designation(reader);
            }

            return designation;
        }

        public static void UpdateDesignation(Designation designation)
        {

            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("UPDATE Designation SET  DesignationName=@DesignationName  WHERE Id=@Id");
            db.AddInParameter(cmd, "DesignationName", DbType.String, designation.designationName);
            db.AddInParameter(cmd, "Id", DbType.Int32, designation.id);

            db.ExecuteNonQuery(cmd);
        }

        public static Designation GetByDesignationName(string designationName)
        {
            Designation designation = null;
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Designation WHERE DesignationName=@DesignationName");
            db.AddInParameter(cmd, "DesignationName", DbType.String, designationName);
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                designation = new Designation(reader);

            }
            return designation;
        }
    }
}
