using AutoMay.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMay.Utilities
{
    public class CommonDrive
    {
        public IWebDriver driver;


        [OneTimeSetUp]
        public void SetUpActions()

        {
            //open browser
            driver = new ChromeDriver();

            // Login page object created  defined and called LoginSteps function from the login page 
            LoginPage LoginOptions = new LoginPage();
            LoginOptions.LoginSteps(driver);

            //Home page object created defined and called HomePage function 
            Home homeOption = new Home();
            homeOption.HomePage(driver);
        }
        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}

