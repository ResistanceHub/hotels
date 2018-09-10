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
	public class BasePageObject
	{
		// Declaring the variable
		protected readonly IWebDriver Driver;
		public BasePageObject(IWebDriver driver)
		{
			// Initialize 
			Driver = driver;
		}





	}
}
