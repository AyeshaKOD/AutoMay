using AutoMay.Page;
using AutoMay.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMay.Test
{
    [TestFixture]
    [Parallelizable]
    public class Employee_Test : CommonDrive
    {
        [SetUp]
        public void SetUpAction()
        {
            //open browser 
            driver = new ChromeDriver();

            LoginPage LoginPageObject = new LoginPage();
            LoginPageObject.LoginSteps(driver);

            Home HomeObject = new Home();
            HomeObject.GoToEmployeePage(driver);
        }
        [Test]
        public void CreateEmployeeRecord(IWebDriver driver)
        {
            Employee EmployeeObject = new Employee();
            EmployeeObject.CreateEmployee(driver);
        }
        [Test]
        public void EditEmployeeRecord(IWebDriver driver)
        {
            Employee EmployeeObject = new Employee();
            EmployeeObject.EditEmployee(driver);
        }
        [Test]
        public void DeleteEmployeeRecord(IWebDriver driver)
        {
            Employee EmployeeObject = new Employee();
            EmployeeObject.DeleteEmployee(driver);
        }
        [TearDown]
        public void TearDownAction()
        {
            driver.Quit();
        }

    }
}
