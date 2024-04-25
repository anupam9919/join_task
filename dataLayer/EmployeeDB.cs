using coreLayer.BusinessObject;
using System.Data.Common;

using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Xml.Linq;
using NLog;

namespace dataLayer
{
    public class EmployeeDB
    {

        public static void AddEmployee(Employee employee)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand($"INSERT INTO Employees(Name, Email, Phone,Department,Designation,Status, CreatedBy, UpdatedBy  ) VALUES(@Name, @Email, @Phone,@Department,@Designation,@Status, @CreatedBy, @UpdatedBy); SELECT LAST_INSERT_ID()");
            db.AddInParameter(cmd, "Name", DbType.String, employee.Name);
            db.AddInParameter(cmd, "Email", DbType.String, employee.Email);
            db.AddInParameter(cmd, "Phone", DbType.String, employee.Phone);
            db.AddInParameter(cmd, "Department", DbType.String, employee.Department);
            db.AddInParameter(cmd, "Designation", DbType.String, employee.Designation);
            db.AddInParameter(cmd, "Status", DbType.String, employee.Status);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, employee.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, employee.UpdatedBy);
            employee.Id = int.Parse(db.ExecuteScalar(cmd).ToString());




        }
        public static void UpdateEmployee(Employee employee)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("UPDATE Employees SET Name=@Name, Email=@Email, Phone=@Phone, Department=@Department, Status=@Status  WHERE Id=@Id");
            db.AddInParameter(cmd, "Name", DbType.String, employee.Name);
            db.AddInParameter(cmd, "Email", DbType.String, employee.Email);
            db.AddInParameter(cmd, "Phone", DbType.String, employee.Phone);
            db.AddInParameter(cmd, "Id", DbType.Int32, employee.Id);
            db.AddInParameter(cmd, "Department", DbType.String, employee.Department);
            db.AddInParameter(cmd, "Status", DbType.String, employee.Status);

            db.ExecuteNonQuery(cmd);
        }

        public static void DeleteEmployee(int Id)
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM Employees WHERE Id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, Id);
            db.ExecuteNonQuery(cmd);
        }

        public static List<Employee> GetAll()
        {
            List<Employee> employeeList = new List<Employee>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Employees");
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                Employee employee = new Employee(reader);
                employeeList.Add(employee);
            }
            //
            return employeeList;
        }



        public static Employee GetByID(int Id)
        {
            Employee employee = null;

            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd2 = db.GetSqlStringCommand("SELECT * FROM Employees WHERE ID=@Id");
            db.AddInParameter(cmd2, "ID", DbType.String, Id);
            IDataReader reader = db.ExecuteReader(cmd2);
            if (reader.Read())
            {
                employee = new Employee();
                employee.Id = int.Parse(reader["Id"].ToString());
                employee.Name = reader["Name"].ToString();
                employee.Email = reader["Email"].ToString();
                employee.Phone = reader["Phone"].ToString();
                employee.Department = reader["Department"].ToString();
                employee.Status = reader["Status"].ToString();



            }
            return employee;

        }


        public static Employee GetByEmail(string Email)
        {
            Employee employee = null;

            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Employees WHERE Email=@Email");
            db.AddInParameter(cmd, "Email", DbType.String, Email);
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                employee = new Employee(reader);

            }

            return employee;

        }


        public static Employee GetByName(string Name)
        {
            Employee employee = null;

            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");

            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Employees WHERE Name=@Name");
            db.AddInParameter(cmd, "Name", DbType.String, Name);
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                employee = new Employee(reader);
            }
            return employee;

        }

        public static List<Employee> GetEmpData()
        {
            List<Employee> employeeList = new List<Employee>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("SELECT e.Id, e.Name AS Name , e.Email AS Email, e.Phone AS Phone, e.Department AS Department,e.Designation as Designation, e.Status AS Status, e.CreatedBy AS CreatedBy, e.UpdatedBy AS UpdatedBy,e.CreatedOnUTC AS CreatedOnUTC,e.UpdatedOnUTC AS UpdatedOnUTC,  d.Name AS DepartmentName, d.Description AS DepartmentDescription FROM Employees e LEFT JOIN Department d ON e.Department = d.Name");
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                Employee employee = new Employee(reader);
                employee.DepartmentDescription = reader["DepartmentDescription"].ToString();
                employeeList.Add(employee);
            }
            return employeeList;
        }



        public static List<Employee> GetEmpWfh()
        {
            List<Employee> employeeWfhList = new List<Employee>();
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
            Database db = DatabaseFactory.CreateDatabase("Local");
            DbCommand cmd = db.GetSqlStringCommand("SELECT e.Id, e.Name AS Name , e.Email AS Email,e.Phone as Phone   ,e.Department AS Department, e.CreatedBy AS CreatedBy, e.UpdatedBy AS UpdatedBy,e.CreatedOnUTC AS CreatedOnUTC,e.UpdatedOnUTC AS UpdatedOnUTC,e.Designation as Designation, w.WfhStatus AS Status, w.StartDate as startDate,w.EndDate as endDate, w.Reason as reason, w.Duration as duration FROM Employees e LEFT JOIN Wfh w ON  e.Id=w.EmpId WHERE w.EmpId IS NOT NULL ");
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                Employee employeeWfh = new Employee(reader);
                employeeWfh.startDate = reader["startDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["startDate"]);
                employeeWfh.endDate = reader["endDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["endDate"]);

                employeeWfh.reason = reader["reason"] == DBNull.Value ? string.Empty : reader["reason"].ToString();
                employeeWfh.duration = reader["duration"] == DBNull.Value ? 0 : Convert.ToInt32(reader["duration"]);
                employeeWfh.WfhStatus = reader["Status"].ToString();

                employeeWfhList.Add(employeeWfh);
            }
            return employeeWfhList;
        }
    }
}
