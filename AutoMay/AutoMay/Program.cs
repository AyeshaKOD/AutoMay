using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // open web driver
        IWebDriver driver = new ChromeDriver();

        // open url 
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

        //Enter username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        //Enter password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        //Click Login button
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(1000);

        //check whether a user has been successfully logged in or not 
        IWebElement displayUserTextbox = driver.FindElement(By.XPath("/html/body/div[3]/div/div/form/ul/li/a"));

        if (displayUserTextbox.Text == "Hello hari!")
        {
            Console.WriteLine("User has successfully logged in");

        }
        else
        {
            Console.WriteLine("User has not successfully logged");
        }

        //Create a new time/materials tab

        //open time & materials under administration tab
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationTab.Click();

        IWebElement optionDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        optionDropdown.Click();

        //Create a new record 
        IWebElement createNewButton = driver.FindElement(By.XPath("/html/body/div[4]/p/a"));
        createNewButton.Click();

        //fill out relevant fields to create a new record 
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[1]"));
        typeCodeDropdown.Click();

        IWebElement timeOption = driver.FindElement(By.XPath("/html/body/div[5]/div/ul/li[2]")); 
        timeOption.Click();

        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("AutoMay");

        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("first test");

        IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTextbox.SendKeys("40");

        //click save button to submit those details and create a record 
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(1000);

        //Go to last page to find our record 
        IWebElement lastButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        lastButton.Click();
        Thread.Sleep(2000);

        //find the last record on list page 
        IWebElement lastCodeText = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        
        if (lastCodeText.Text == "AutoMay")
        {
            Console.WriteLine("New record created successfully");
        }
        else
        {
            Console.WriteLine("New record was not created");
        }


        // edit record AutoMay
        
        //we select a record to edit
        if (lastCodeText.Text == "AutoMay")
        {
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            IWebElement codeEditText = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            codeEditText.Clear();
            codeEditText.SendKeys("ExMay");

            IWebElement saveEditButton = driver.FindElement(By.Id("SaveButton"));
            saveEditButton.Click();
            Thread.Sleep(2000);

            Console.WriteLine("Record code edited successfully");

        }
        else
        {
            Console.WriteLine("Record not edited successfully");
        }

        // delete record 
        //Select a record from last  page 
        IWebElement lastdelButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
        lastdelButton.Click();

        //IWebElement toDelText = driver.FindElement(By.Id("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));
        if (lastCodeText.Text == "AutoMay")
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[2]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(3000);

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);

            //Check the list again to make sure the record is deleted 
            if (lastButton.Text == string.Empty)
            {
                Console.WriteLine("Item deleted successfully ");
            }
            else
            {
                Console.WriteLine("Item not deleted successfully");
            }
            }
        }



    }

