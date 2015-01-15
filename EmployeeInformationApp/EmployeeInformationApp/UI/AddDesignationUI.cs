using System;
using System.Windows.Forms;
using EmployeeInformationApp.BLL;
using EmployeeInformationApp.DAL.DAO;

namespace EmployeeInformationApp.UI
{
    public partial class AddDesignationUI : Form
    {
        public AddDesignationUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
           Designation aDesignation = new Designation();
           aDesignation.Code = codeTextBox.Text;
           aDesignation.Title = titleTextBox.Text;
           DesignationManager aDesignationManager = new DesignationManager();
           string msg = aDesignationManager.SaveDesignation(aDesignation);
           MessageBox.Show(msg);
        }
    }
}
