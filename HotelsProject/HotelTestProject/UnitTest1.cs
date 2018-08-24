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
			var homePage = new HomePage(driver);
			var expectedText = "Find your ideal hotel and compare prices from different websites";
			var actualText = homePage.Title();
			Assert.AreEqual(expectedText, actualText);
		}

		[TestMethod]
		public void SearchFromSearchPage()
		{
			var homePage = new HomePage(driver);
			var searchSection = homePage.GetSearchSection();
			searchSection.Search("London");
			var searchPage = new SearchPage(driver);
			searchPage.GetSearchSection().Search("Liverpool");
		}
	}
}
