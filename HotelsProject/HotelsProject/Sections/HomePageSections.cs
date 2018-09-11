using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsProject.PageObjetcs;
using OpenQA.Selenium;

namespace HotelsProject.Sections
{
	public class HomePageSections : BaseObject
	{
		private const string searchSectionSelector = "div.horus__row--query";
		public SearchSection SearchSection => new SearchSection(Driver, searchSectionSelector);

		public HomePageSections(IWebDriver driver) : base(driver)
		{
		}
	}
}
