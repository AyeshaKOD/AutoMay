
using NUnit.Framework;
using OpenQA.Selenium;
using AutoMay.Utilities;
using System.Diagnostics;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;


namespace AutoMay.Page
{
    public class TMPage :CommonDrive
    {
        public void CreateRecord(IWebDriver driver)
        {
            //click create new record button and fill out relevant fields to create a new record 
            IWebElement createRecordButton = driver.FindElement(By.XPath("/html/body/div[4]/p/a"));
            createRecordButton.Click();
            Thread.Sleep(3000);

            IWebElement typeCode = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[1]"));
            typeCode.Click();

            IWebElement timeDropDown = driver.FindElement(By.XPath("/html/body/div[5]/div/ul/li[2]"));
            timeDropDown.Click();

            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("AutoMay");

            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("first test");

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("40");

            //click save button to submit those details and create a record 
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);

            //Go to last page on records list 
            IWebElement lastCodePage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
            lastCodePage.Click();
            Thread.Sleep(3000);

            //find the last record on list page                     
            IWebElement lastRecordText = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement typeRecordText = driver.FindElement(By.Id("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement descriptionRecordText = driver.FindElement(By.Id("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement priceRecordText = driver.FindElement(By.Id("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[4]"));


            //Assertion method 2
            Assert.That(lastRecordText.Text == "AutoMay", "Actual code and expected code do not match");
            Assert.That(typeRecordText.Text == "T", "Actual type code and expected type code do not match");
            Assert.That(descriptionRecordText.Text == "first test", "Actual description and expected description do not match");
            Assert.That(priceRecordText.Text == "$40.00", "Actual price and expected price do not match");


        }
        public void EditRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);
            // edit record AutoMay
            // First go to last page 
            IWebElement lastCodePage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
            lastCodePage.Click();

            //Select last record on the last page 
            IWebElement lastEditRecord = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lastEditRecord.Text == "AutoMay")
            {
                
                IWebElement editButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("Edit record was not successful");
            }


            // change details on opened record 

            
            IWebElement codeEditText = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            codeEditText.Clear();
            codeEditText.SendKeys("ExMay");
           


            IWebElement descriptionText = driver.FindElement(By.Id("Description"));
            descriptionText.Clear();
            descriptionText.SendKeys("List");
            

            IWebElement editPriceOverlap = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPrice = driver.FindElement(By.Id("Price"));
            editPriceOverlap.Click();
            editPrice.Clear();
            editPriceOverlap.Click();
            editPrice.SendKeys("50");
            

            IWebElement saveEditButton = driver.FindElement(By.Id("SaveButton"));
            saveEditButton.Click();
            Thread.Sleep(2000);
        }
        public void DeleteRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);
            // delete record 
            //select last page
            IWebElement lastCodePage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
            lastCodePage.Click();
            Thread.Sleep(2000);

            //select last record on the last page 
            IWebElement lastDeleteRecord = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lastDeleteRecord.Text == "AutoMay")
            {                                                              
                IWebElement deleteButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
            }

            else
            {
                Assert.Fail("Record not found to delete ");
            }

            Thread.Sleep(3000);

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);

            if (lastDeleteRecord.Text != "AutoMay")
            {
                Assert.Pass("Last record deleted successfully");
            }
            else
            {
                Assert.Fail("Record deletion was not successful");
            }
        }
    }
}
