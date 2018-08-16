using System;
using OpenQA.Selenium;

namespace HotelSearch.PageObjects
{
    class HomePage
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)//constructor to assign the Web driver once for all method on the home page
        {
            _driver = driver;//make private to public
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        } 
        public void SearchItem(string cityName)
        {
            var search = _driver.FindElement(By.Id("horus-querytext"));
            if (search == null) throw new ArgumentNullException(nameof(search));
            search.SendKeys(cityName);
            _driver.FindElement(By.ClassName("horus-btn-search")).Click(); //click search button
        }
    }
}
