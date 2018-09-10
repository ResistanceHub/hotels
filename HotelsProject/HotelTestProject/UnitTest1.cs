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
			// Where we say new we call it Instantiate
			HomePage homePage = new HomePage(driver);
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

		[TestMethod]
		public void VerifyOrderOfResults()
		{
			const string firstHotelName = "The Nadler Kensington";
//			const string secondHotelName = "The Nadler Soho";
//			const string lastHotelName = "Travelodge London Covent Garden";

			var homePage = new HomePage(driver);
			homePage.GetSearchSection().Search("London");

			var searchPage = new SearchPage(driver);
			var actualFirstHotelName = searchPage.GetHotelSection(1).Name();
			var actualSecondHotelName = searchPage.GetHotelSection(2).Name();
			var actualLastHotelName = searchPage.GetHotelSection(25).Name();
			Assert.AreEqual(firstHotelName, actualFirstHotelName);
//			Assert.AreEqual(secondHotelName, actualSecondHotelName);
//			Assert.AreEqual(lastHotelName, actualLastHotelName);
		}
	}
}
