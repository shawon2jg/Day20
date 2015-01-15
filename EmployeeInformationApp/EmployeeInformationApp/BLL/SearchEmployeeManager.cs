using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationApp.DAL.DAO;
using EmployeeInformationApp.DAL.DBGateway;

namespace EmployeeInformationApp.BLL
{
    class SearchEmployeeManager
    {
        SearchEmployeeDBGatewaye aSearchEmployeeDBGatewaye = new SearchEmployeeDBGatewaye();
        public List<Employee> GetAllEmployeeList(string enterName)
        {
            return aSearchEmployeeDBGatewaye.GetAllEmployeeList(enterName);
        }
    }
}
