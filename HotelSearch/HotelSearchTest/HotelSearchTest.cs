using System;
using HotelSearch.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HotelSearchTest
{
    [TestClass]
    public class HotelSearchTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialise()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.trivago.co.uk";
        }

        [TestCleanup]

        public void TestCleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void HotelTitleOnHomePage()//first testing scenario
        {
            driver.FindElement(By.ClassName("btn--accept")).Click();
            var homePage = new HomePage(driver);
            var expectedTitle = "Find your ideal hotel and compare prices from different websites";
            var actualTitle = homePage.Title();
            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}
