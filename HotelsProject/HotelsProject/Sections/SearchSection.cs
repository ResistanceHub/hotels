using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsProject.PageObjetcs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HotelsProject.Sections
{
	public class SearchSection : BaseSection
	{
		public SearchSection(IWebDriver driver, string sectionSelector) : base(driver, sectionSelector)
		{
		}

		public void Search(string location)
		{
			// Scope the searches to the actual section on the page
			// which is within element: div.horus__row--query
			var rootSelection = Driver.FindElement(By.CssSelector(SectionSelector));
			var searchTextField = rootSelection.FindElement(By.CssSelector( "#horus-querytext"));
			searchTextField.SendKeys(location);
			System.Threading.Thread.Sleep(1000);
			rootSelection.FindElement(By.CssSelector("#js-fullscreen-hero form button.horus-btn-search")).Click();
			System.Threading.Thread.Sleep(7000);

			//			var searchTextField = _driver.FindElement(By.CssSelector($"{_sectionSelector} #horus-querytext"));
			//			searchTextField.SendKeys(location);
			//			System.Threading.Thread.Sleep(1000);
			//			_driver.FindElement(By.CssSelector($"{_sectionSelector} #js-fullscreen-hero form button.horus-btn-search")).Click();
			//			System.Threading.Thread.Sleep(5000);
		}
	}
}
	