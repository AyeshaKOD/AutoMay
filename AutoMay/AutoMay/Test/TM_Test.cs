using AutoMay.Page;
using AutoMay.Utilities;
using Microsoft.VisualBasic.FileIO;
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
    public class TM_Test:CommonDrive
    {
        
        [Test, Order(1)]
        public void CreateRecordTest()
        {
            // TMPage object created, defined and called CreateRecord function, EditRecord function and DeleteRecord function
            TMPage tmOption = new TMPage();
            tmOption.CreateRecord(driver);
            
            
        }
        [Test, Order(2)]
        public void EditRecordAction()
        {
            TMPage tmOption = new TMPage();
            tmOption.EditRecord(driver);
        }
        [Test, Order(3)]
        public void DeleteRecordAction()
        {
            TMPage tmOption = new TMPage();
            tmOption.DeleteRecord(driver);
        }
        
    }
}
