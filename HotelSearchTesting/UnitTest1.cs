using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HotelSearch.PageObjects;

namespace HotelSearchTesting
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void Init()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.trivago.co.uk";
        }

        [TestCleanup]
        public void TEstCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void Testmethod1()
        {
            _driver.FindElement(By.ClassName("btn--accept")).Click();
            var homePage = new HomePage(_driver);

        }
    }
}
