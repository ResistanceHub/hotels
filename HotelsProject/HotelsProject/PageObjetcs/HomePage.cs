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
	public class HomePage : BasePageObject
	{
		private const string searchSelectionSelector = "div.horus__row--query";
		public HomePage(IWebDriver driver) : base(driver)
		{
		}

		public SearchSection GetSearchSection()
		{
			return new SearchSection(Driver, searchSelectionSelector);
		}

		public string Title()
		{
			var title = Driver.FindElement(By.CssSelector("#js-fullscreen-hero .hero__line"));
			return title.Text;
		}
	}
}
