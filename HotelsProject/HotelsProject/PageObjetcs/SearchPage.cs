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
	public class SearchPage: PageObject
	{
		private const string searchSelectionSelector = "div.horus__row--query";

		public SearchPage(IWebDriver driver):base(driver)
		{	
		}

		public SearchSection GetSearchSection()
		{
			return new SearchSection(_driver, searchSelectionSelector);
		}

	}
}
