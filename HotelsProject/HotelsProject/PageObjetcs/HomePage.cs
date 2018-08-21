using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HotelsProject.PageObjetcs
{
	public class HomePage : PageObject
	{
//		private readonly IWebDriver _driver;
		public HomePage(IWebDriver driver) : base(driver)
		{
		}

		public void Search(string location)
		{
			var searchTextField = _driver.FindElement(By.Id("horus-querytext"));
			searchTextField.SendKeys("London");
			_driver.FindElement(By.CssSelector("[ref~='searchButton']")).Click();
		}

		public string Title()
		{
			var title = _driver.FindElement(By.CssSelector("#js-fullscreen-hero .hero__line"));
			return title.Text;
		}
	}
}
