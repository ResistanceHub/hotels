using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsProject.Sections;
using OpenQA.Selenium;

namespace HotelsProject.PageObjetcs
{
	public class HomePage : PageObject
	{
		private const string searchSelectionSelector = "div.horus__row--query";
		public HomePage(IWebDriver driver) : base(driver)
		{
		}

		public SearchSection GetSearchSection()
		{
			return new SearchSection(_driver, searchSelectionSelector);
		}

		public string Title()
		{
			var title = _driver.FindElement(By.CssSelector("#js-fullscreen-hero .hero__line"));
			return title.Text;
		}
	}
}
