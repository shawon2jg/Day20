using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountTransactionApp
{
    public partial class BankAccountTransactionUI : Form
    {
        Customer aCustomer = new Customer();
        private double getDeposit;
        private double amount;
        public BankAccountTransactionUI()
        {
            InitializeComponent();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            aCustomer.AccountNumber = accountNumberTextBox.Text;
            aCustomer.Name = customerNameTextBox.Text;
            MessageBox.Show("Account Created Successfully!");
        }
        
        private void depositeButton_Click(object sender, EventArgs e)
        {
            amount = Convert.ToDouble(amountTextBox.Text);
            string msg = aCustomer.GivenDeposit(amount);
            MessageBox.Show(msg);
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            amount = Convert.ToDouble(amountTextBox.Text);
            string msg = aCustomer.GetWithdraw(amount);
            MessageBox.Show(msg);
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(aCustomer.GetReport());
        }
    }
}
