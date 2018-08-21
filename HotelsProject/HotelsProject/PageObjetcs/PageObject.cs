using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// parent of all page objects
namespace HotelsProject.PageObjetcs
{
	public class PageObject
	{
		protected readonly IWebDriver _driver;
//		private readonly string _url;
		public PageObject(IWebDriver driver)
		{
			_driver = driver;
//			_url = url;
		}

//		public void GoToPage()
//		{
//			_driver.Url = _url;
//		}



	}
}
