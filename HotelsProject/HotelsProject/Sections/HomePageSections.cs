using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HotelsProject.Sections
{
	public class HomePageSections
	{
		private readonly IWebDriver driver;
		private const string searchSectionSelector = "div.horus__row--query";
		public SearchSection SearchSection => new SearchSection(driver, searchSectionSelector);

		public HomePageSections(IWebDriver driver)
		{
			this.driver = driver;
			
		}
	}
}
