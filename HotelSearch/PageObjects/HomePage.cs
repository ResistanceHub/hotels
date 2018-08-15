using System;
using OpenQA.Selenium;

namespace HotelSearch.PageObjects
{
    class HomePage
    {
        private IWebDriver _driver;
        public HomePage(IWebDriver driver)//constructor to assign the Web driver once for all method on the home page
        {
            _driver = driver;//make private to public
        }       
        public void Search(string location)
        {
            var Search = _driver.FindElement(By.Id("horus-querytext"));
            if (Search == null) throw new ArgumentNullException(nameof(Search));
            Search.SendKeys("London");
            _driver.FindElement(By.ClassName("horus-btn-search")).Click(); //click search button
        }
    }
}
