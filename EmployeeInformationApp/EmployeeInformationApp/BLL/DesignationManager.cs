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
    public class DesignationManager
    {
        private const int MIN_LENGTH_OF_CODE = 2;
        DesignationDBGateway aDesignationDBGateway = new DesignationDBGateway();
        public string SaveDesignation(Designation aDesignation)
        {
            if (aDesignation.Code.Length >= MIN_LENGTH_OF_CODE)
            {
                Designation designationFound = aDesignationDBGateway.FindDesignationCode(aDesignation.Code);
                if (designationFound == null)
                {
                    aDesignationDBGateway.SaveDesignation(aDesignation);
                    return "Successfully Saved!"; 
                }
                else
                {
                    return "The code already exsist";
                }
            }
            else
            {
                return "Code must be "+ MIN_LENGTH_OF_CODE +" char long";
            }
        }
    }
}
