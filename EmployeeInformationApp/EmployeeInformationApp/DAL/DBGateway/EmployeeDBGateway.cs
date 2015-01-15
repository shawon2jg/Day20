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
    class EmployeeDBGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
        private SqlConnection connection;
        public void SaveEmployee(Employee aEmployee, Designation selecteDesignation)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO tbl_employee VALUES('" + aEmployee.Name + "','" + aEmployee.Email + "','" + aEmployee.Address + "','" + selecteDesignation.DesId + "')";
            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            aSqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateEmployee(Employee aEmployee, Designation selectedDesignation)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "Update tbl_employee SET name ='" + aEmployee.Name + "',email='" + aEmployee.Email + "',address='" + aEmployee.Address + "' WHERE emp_id = '" + aEmployee.EmpId + "'";
            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            aSqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public Employee FindEmail(string email)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM tbl_employee WHERE email = '" + email + "' ";
            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();

            if (aSqlDataReader.HasRows)
            {
                Employee aEmployee = new Employee();
                aSqlDataReader.Read();
                aEmployee.EmpId = Convert.ToInt32(aSqlDataReader["emp_id"]);
                aEmployee.Name = aSqlDataReader["name"].ToString();
                aEmployee.Email = aSqlDataReader["email"].ToString();
                aEmployee.Address = aSqlDataReader["address"].ToString();
                aSqlDataReader.Close();
                connection.Close();
                return aEmployee;
            }
            else
            {
                connection.Close();
                return null;
            }
        }
        public List<Designation> GetAllDesignationList()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM tbl_designation";
            SqlCommand aCommand = new SqlCommand(query, connection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            List<Designation> designationList = new List<Designation>();
            while (aReader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.DesId = (int)aReader["des_id"];
                //aDesignation.Code = aReader["code"].ToString();
                aDesignation.Title = aReader["title"].ToString();

                designationList.Add(aDesignation);
            }
            aReader.Close();
            connection.Close();
            return designationList;
        }
    }
}
