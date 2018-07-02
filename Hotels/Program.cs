using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trivago.co.uk/");
            IWebElement city = driver.FindElement(By.Id("horus-querytext"));
            city.SendKeys("London");
            driver.FindElement(By.ClassName("horus-btn-search__icon")).Click();

        }
    }
}

