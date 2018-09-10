using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HotelsProject.Sections
{
	
	public class HotelSection
	{
		private readonly IWebDriver driver;
		private readonly string hotelSectionSelector;

		public HotelSection(IWebDriver driver, string hotelSectionSelector)
		{
			this.driver = driver;
			this.hotelSectionSelector = hotelSectionSelector;
		}


		private IWebElement GetNameElement()
		{
			var rootSelection = driver.FindElement(By.CssSelector(hotelSectionSelector));
			var nameElement = rootSelection.FindElement(By.CssSelector("h3.name__copytext"));
			return nameElement;
		}
		
		public string Name()
		{
			return GetNameElement().Text;
		}


		public void OpenDetails()
		{
			GetNameElement().Click();
		}
	}
}
