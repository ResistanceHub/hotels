using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsProject.PageObjetcs;
using OpenQA.Selenium;

namespace HotelsProject.Sections
{
	
	public class HotelSection : BaseSection
	{
		

		public HotelSection(IWebDriver driver, string hotelSectionSelector) : base(driver, hotelSectionSelector)
		{
		}

		private IWebElement GetNameElement()
		{
			var rootSelection = Driver.FindElement(By.CssSelector(SectionSelector));
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
