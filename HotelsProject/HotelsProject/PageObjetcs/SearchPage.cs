using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HotelsProject.PageObjetcs
{
	public class SearchPage: PageObject
	{
//		private readonly IWebDriver _driver;
		public SearchPage(IWebDriver driver):base(driver)
		{	
//			_driver = driver;
		}

//		public void Search(string location)
//		{
//			var searchTextField = _driver.FindElement(By.Id("horus-querytext"));
//			searchTextField.SendKeys("London");
//			_driver.FindElement(By.CssSelector("[ref~='searchButton']")).Click();
//		}
	}
}
