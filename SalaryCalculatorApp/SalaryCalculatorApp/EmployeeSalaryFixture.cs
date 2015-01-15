using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SalaryCalculatorApp
{
    [TestFixture]
    class EmployeeSalaryFixture
    {
        private EmployeeSalary anEmployeeSalary;

        [SetUp]
        public void initialize()
        {
            anEmployeeSalary = new EmployeeSalary();
        }

        [Test]
        public void initalSalaryTest()
        {
            Assert.AreEqual(0, anEmployeeSalary.CalculateTotalSalary());
        }

        [Test]
        public void SalaryWithoutAllowanceTest()
        {
            anEmployeeSalary.basicSalary = 1000;
            anEmployeeSalary.houseRent = 0;
            anEmployeeSalary.medicalAllowance = 0;
            
            Assert.AreEqual(1000, anEmployeeSalary.CalculateTotalSalary());
        }

        [Test]
        public void SalaryWithHouseRentTest()
        {
            anEmployeeSalary.basicSalary = 1000;
            anEmployeeSalary.houseRent = 2;
            anEmployeeSalary.medicalAllowance = 0;

            Assert.AreEqual(1020, anEmployeeSalary.CalculateTotalSalary());
        }

        [Test]
        public void SalaryWithMedicalAllowanceTest()
        {
            anEmployeeSalary.basicSalary = 1000;
            anEmployeeSalary.houseRent = 0;
            anEmployeeSalary.medicalAllowance = 3;

            Assert.AreEqual(1030, anEmployeeSalary.CalculateTotalSalary());
        }

        [Test]
        public void SalaryWithHouseRentAndMedicalAllowanceTest()
        {
            anEmployeeSalary.basicSalary = 1000;
            anEmployeeSalary.houseRent = 2;
            anEmployeeSalary.medicalAllowance = 3;

            Assert.AreEqual(1050, anEmployeeSalary.CalculateTotalSalary());
        }

        [TearDown]
        public void End()
        {
            anEmployeeSalary = null;
        }

    }
}
