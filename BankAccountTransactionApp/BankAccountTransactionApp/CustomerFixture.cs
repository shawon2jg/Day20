using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BankAccountTransactionApp
{
    [TestFixture]
    public class CustomerFixture
    {
        private Customer aCustomer;
        [SetUp]
        public void init()
        {
            aCustomer = new Customer();
        }

        [Test]
        public void intialBalanceTest()
        {
            Assert.AreEqual(0, aCustomer.Balance);
        }

        [Test]
        public void DepositTest()
        {
            aCustomer.GivenDeposit(500);
            Assert.AreEqual(500, aCustomer.Balance);
        }

        [Test]
        public void WithdrawTest()
        {
            aCustomer.GivenDeposit(550);
            aCustomer.GetWithdraw(200);
            Assert.AreEqual(350, aCustomer.Balance);
        }

        [Test]
        public void IsSufficientBalance()
        {
            aCustomer.GivenDeposit(400);
            aCustomer.GetWithdraw(230);
            aCustomer.GetWithdraw(500);
            Assert.AreEqual(170, aCustomer.Balance);
        }

        [TearDown]
        public void End()
        {
            aCustomer = null;
        }
    }
}
