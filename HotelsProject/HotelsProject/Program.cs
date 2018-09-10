using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsProject.PageObjetcs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HotelsProject
{
	class Program
	{
		// id use a #
		// class use .
		// tag use the name of the tag e.g. h1, div

		static void Main(string[] args)
		{
			IWebDriver driver = new ChromeDriver();
			driver.Url = "https://www.trivago.co.uk";

			driver.FindElement(By.ClassName("btn--accept")).Click();

//			var homePage = new HomePage(driver);
//			homePage.Search("London");
			
//			homePage.FindElementById()
//			homePage.GoToPage();
//			homePage._url = "";

			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			wait.Until((d) => d.FindElement(By.ClassName("overlay__close")));
			
			driver.FindElement(By.ClassName("overlay__close")).Click();

//			var wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			wait.Until(d => d.FindElement(By.CssSelector(".refinement-row__btn.btn--primary")));
			driver.FindElement(By.CssSelector(".refinement-row__btn.btn--primary")).Click();

			Console.WriteLine("Press any key to close broweser");
			Console.ReadKey();
			driver.Quit();
//			Console.WriteLine("Press any key to close the application");
//			Console.ReadKey();
		}
	}
}
