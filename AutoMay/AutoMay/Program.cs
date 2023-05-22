using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        usernameTextbox.SendKeys("ahasnetha");

        //Enter password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("an1234");

        //Click Login button
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(1000);

        //check whether a user has been successfully logged in or not 
        IWebElement displayUserTextbox = driver.FindElement(By.XPath("/html/body/div[3]/div/div/form/ul/li/a"));

        if (displayUserTextbox.Text == "Hello ahasnetha!")
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
    }
}