using AutoMay.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace AutoMay.Page
{
    public class LoginPage:CommonDrive 
    {
            public void LoginSteps(IWebDriver driver)
        {
            // open url 
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            Wait.WaitToBeClickable(driver, "Id", "UserName", 7);

            //Enter username
            try
            {
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");
            }
            catch (Exception ex)
            {
                Assert.Fail("Turn up portal did not load", ex);
            }


            //Enter password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            

            //Click Login button

            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(2000);

        }
    }
}
