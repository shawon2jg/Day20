using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EmployeeInformationApp.DAL.DAO;
using EmployeeInformationApp.DAL.DBGateway;

namespace EmployeeInformationApp.BLL
{
    class EmployeeManager
    {
        EmployeeDBGateway aEmployeeDBGateway = new EmployeeDBGateway();
        public string SaveEmployee(Employee aEmployee, Designation selecteDesignation)
        {
            Employee emailFound = aEmployeeDBGateway.FindEmail(aEmployee.Email);
            if (IsValidEmail(aEmployee.Email))
            {
                if (emailFound == null)
                {
                    aEmployeeDBGateway.SaveEmployee(aEmployee, selecteDesignation);
                    return "Successfully Saved!";
                }
                else
                {
                    return "The Email Already Exsits...!!!!!!";
                }
            }
            else
            {
                return "Please Type Valid Email..!!!!!!!";
            }
        }

        public bool IsValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public List<Designation> LoadAllDesignationList()
        {
            return aEmployeeDBGateway.GetAllDesignationList();
        }

        public string UpdateEmployee(Employee aEmployee, Designation selectedDesignation)
        {
            if (IsValidEmail(aEmployee.Email))
            {
                aEmployeeDBGateway.UpdateEmployee(aEmployee, selectedDesignation);
                return "Successfully Updated!";
            }
            else
            {
                return "Please Type Valid Email..!!!!!!!";
            }
        }
    }
}
