using System;
using HotelsProject.PageObjetcs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HotelTestProject
{
	[TestClass]
	public class UnitTest1
	{
		private IWebDriver driver;

		[TestInitialize]
		public void Init()
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
		public void TestMethod1()
		{
			driver.FindElement(By.ClassName("btn--accept")).Click();
			var homePage = new HomePage(driver);
			var expectedText = "Find your ideal hotel and compare prices from different websites";

			var actualText = homePage.Title();
			Assert.AreEqual(expectedText, actualText);

		}
	}
}
