using AutoMay.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMay.Page
{
    public class Home
    {
        public void HomePage(IWebDriver driver)
        {
            //open time & materials under administration tab 
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 7);
                                                                        
            IWebElement optionDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            optionDropdown.Click();
        }
        public void GoToEmployeePage(IWebDriver driver)
        {
            //open employee tab  under administration tab 
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            Wait.WaitToBeClickable(driver, "XPath","/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 7);

            IWebElement employeeOptionDropDown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
            employeeOptionDropDown.Click();
        }
    }
}
