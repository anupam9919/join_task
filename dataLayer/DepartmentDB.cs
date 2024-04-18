using coreLayer.BusinessObject;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataLayer
{
    public static class DepartmentDB
    {
        public static void AddDepartment(Department department)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand($"INSERT INTO Department(Name, Description, CreatedBy, UpdatedBy) VALUES(@Name, @Description, @CreatedBy, @UpdatedBy); SELECT LAST_INSERT_ID()");
            db.AddInParameter(cmd, "Name", DbType.String, department.Name);
            db.AddInParameter(cmd, "Description", DbType.String, department.Description);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, department.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, department.UpdatedBy);

            department.Id = int.Parse(db.ExecuteScalar(cmd).ToString());

        }
        public static List<Department> GetAll()
        {
            List<Department> deptList = new List<Department>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Department");
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                Department department = new Department(reader);
                deptList.Add(department);
            }
            //
            return deptList;
        }

        public static Department GetByID(int Id)
        {
            Department department = null;

            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd2 = db.GetSqlStringCommand("SELECT * FROM Department WHERE ID=@Id");
            db.AddInParameter(cmd2, "ID", DbType.String, Id);
            IDataReader reader = db.ExecuteReader(cmd2);
            if (reader.Read())
            {
                department = new Department();
                department.Id = int.Parse(reader["Id"].ToString());
                department.Name = reader["Name"].ToString();
                department.Description = reader["Description"].ToString();
            }
            return department;

        }

        public static void UpdateDepartment(Department department)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("UPDATE Department SET Name=@Name, Description=@Description  WHERE Id=@Id");
            db.AddInParameter(cmd, "Name", DbType.String, department.Name);
            db.AddInParameter(cmd, "Description", DbType.String, department.Description);
            db.AddInParameter(cmd, "Id", DbType.Int32, department.Id);

            db.ExecuteNonQuery(cmd);
        }


        public static void DeleteDepartment(int Id)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM Department WHERE Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.Int32, Id);
            db.ExecuteNonQuery(cmd);
        }

        public static Department GetByDeptName(string Name)
        {
            Department department = null;

            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Department WHERE Name=@Name");
            db.AddInParameter(cmd, "Name", DbType.String, Name);
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                department = new Department(reader);

            }

            return department;

        }
    }


}
