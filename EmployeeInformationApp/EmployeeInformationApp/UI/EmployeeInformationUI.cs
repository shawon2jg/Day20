using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using EmployeeInformationApp.BLL;
using EmployeeInformationApp.DAL.DAO;
using EmployeeInformationApp.DAL.DBGateway;

namespace EmployeeInformationApp.UI
{

    public partial class EmployeeInformationUI : Form
    {
        
        public EmployeeInformationUI()
        {
            InitializeComponent();
            updateButton.Visible = false;
            idTextBox.Visible = false;
            idLabel.Visible = false;
            idTextBox.Visible = false;
        }
        EmployeeManager aEmployeeManager = new EmployeeManager();
        private Designation selectedDesignation;
        public void ButtonVisible()
        {
            updateButton.Visible = true;
            saveButton.Visible = false;
            idLabel.Visible = true;
            idTextBox.Visible = true;
            idTextBox.ReadOnly = true;
        }
        public void saveButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee = new Employee();
            aEmployee.Name = nameTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            selectedDesignation = (Designation)designationComboBox.SelectedItem;
            
            string msg = aEmployeeManager.SaveEmployee(aEmployee, selectedDesignation);
            MessageBox.Show(msg);
        }

        private void EmployeeInformationUI_Load(object sender, EventArgs e)
        {
            designationComboBox.DataSource = aEmployeeManager.LoadAllDesignationList();
            designationComboBox.DisplayMember = "Title";
            designationComboBox.ValueMember = "DesId";
        }

        public void ShowEmployee(ListViewItem selectedItem)
        {
            Employee selectedEmployee = (Employee) selectedItem.Tag;
            idTextBox.Text = selectedEmployee.EmpId.ToString();
            nameTextBox.Text = selectedEmployee.Name;
            emailTextBox.Text = selectedEmployee.Email;
            addressTextBox.Text = selectedEmployee.Address;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee = new Employee();
            aEmployee.EmpId = Convert.ToInt32(idTextBox.Text);
            aEmployee.Name = nameTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            selectedDesignation = (Designation)designationComboBox.SelectedItem;

            string msg = aEmployeeManager.UpdateEmployee(aEmployee, selectedDesignation);
            MessageBox.Show(msg);
        }
    }
}
