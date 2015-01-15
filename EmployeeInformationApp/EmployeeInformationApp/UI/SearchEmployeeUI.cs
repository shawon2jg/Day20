using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using EmployeeInformationApp.BLL;
using EmployeeInformationApp.DAL.DAO;
using EmployeeInformationApp.DAL.DBGateway;

namespace EmployeeInformationApp.UI
{
    public partial class SearchEmployeeUI : Form
    {
        public SearchEmployeeUI()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string enterName = enterNameTextBox.Text;
            SearchEmployeeManager aSearchEmployeeManager = new SearchEmployeeManager();
            var employeeList = aSearchEmployeeManager.GetAllEmployeeList(enterName);

            searchResultListView.Items.Clear();
            foreach (Employee aEmployees in employeeList)
            {
                ListViewItem aListViewItem = new ListViewItem();
                aListViewItem.Text = aEmployees.EmpId.ToString();
                aListViewItem.SubItems.Add(aEmployees.Name);
                aListViewItem.SubItems.Add(aEmployees.Email);
                aListViewItem.SubItems.Add(aEmployees.Address);

                searchResultListView.Items.Add(aListViewItem);
                aListViewItem.Tag = aEmployees;
            }
        }
        private void updateEmployeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = searchResultListView.SelectedItems[0];
            EmployeeInformationUI aEmployeeInformationUI = new EmployeeInformationUI();
            aEmployeeInformationUI.ShowEmployee(selectedItem);
            aEmployeeInformationUI.ButtonVisible();
            aEmployeeInformationUI.ShowDialog();
        }
    }
}
