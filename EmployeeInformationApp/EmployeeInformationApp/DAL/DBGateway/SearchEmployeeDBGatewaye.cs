using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationApp.DAL.DAO;

namespace EmployeeInformationApp.DAL.DBGateway
{
    class SearchEmployeeDBGatewaye
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
        private SqlConnection connection;
        public List<Employee> GetAllEmployeeList(string enterName)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "";
            if (!string.IsNullOrEmpty(enterName))
            {
                query = "SELECT * FROM tbl_employee WHERE name = '" + enterName + "'";
            }
            else
            {
                query = "SELECT * FROM tbl_employee";
            }
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Employee> employeeList = new List<Employee>();
            while (reader.Read())
            {
                Employee aEmployee = new Employee();
                aEmployee.EmpId = (int)reader["emp_id"];
                aEmployee.Name = reader["name"].ToString();
                aEmployee.Email = reader["email"].ToString();
                aEmployee.Address = reader["address"].ToString();
                employeeList.Add(aEmployee);
            }
            reader.Close();
            connection.Close();
            return employeeList;
        }
    }
}
