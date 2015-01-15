using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformationApp.DAL.DAO;

namespace EmployeeInformationApp.DAL.DBGateway
{
    public class DesignationDBGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
        private SqlConnection connection; 

        public void SaveDesignation(Designation aDesignation)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO tbl_designation VALUES('" + aDesignation.Code + "','" + aDesignation.Title + "')";
            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            aSqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public Designation FindDesignationCode(string code)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM tbl_designation WHERE code = '"+code+"' ";
            SqlCommand aSqlCommand = new SqlCommand(query, connection);
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();

            if (aSqlDataReader.HasRows)
            {
                Designation aDesignation = new Designation();
                aSqlDataReader.Read();
                aDesignation.DesId = Convert.ToInt32(aSqlDataReader["des_id"]);
                aDesignation.Code = aSqlDataReader["code"].ToString();
                aDesignation.Title = aSqlDataReader["title"].ToString();
                aSqlDataReader.Close();
                connection.Close();
                return aDesignation;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        
        

        
    }
}
