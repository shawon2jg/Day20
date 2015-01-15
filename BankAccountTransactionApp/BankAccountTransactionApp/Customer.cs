using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTransactionApp
{
    class Customer
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public string GivenDeposit(double amount)
        {
            Balance += amount;
            return "Successfully Deposited...!!";
        }

        public string GetWithdraw(double amount)
        {
            if ((Balance - amount) >= 0)
            {
                Balance -= amount;
                return "Successfully Deposited...!!";
            }
            else
            {
                return "Sorry.. Balance Cann't Be Negative....!!";
            }
        }

        public string GetReport()
        {
            return Name + ", Your Account No is: " + AccountNumber + " & Balance is: " + Balance;
        }
    }
}
