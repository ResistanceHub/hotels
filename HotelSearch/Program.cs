using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HotelSearch
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trivago.co.uk");
            driver.FindElement(By.Id("horus-querytext")).SendKeys("London");
            driver.FindElement(By.ClassName("horus-btn-search")).Click();

            var ListOfHotels = driver.FindElements(By.CssSelector("h3"));
            for (int i = 0; i <= 15; i++) {
            }
            Console.ReadKey();
        }
    }
}
