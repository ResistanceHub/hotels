using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotels.PageObject
{
    class HomePage
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate()
        {
            _driver.Url = "https://www.trivago.co.uk";
        }
       
    }
}
