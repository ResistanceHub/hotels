using System;
using OpenQA.Selenium;

namespace HotelSearch.PageObjects
{
    public class HomePage : PageObjects
    {
        public HomePage(IWebDriver driver) :
            base(driver) //inheritance driver in PageObjects and assign to all methods on this page
        {

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

        public string Title()
        {
            var title = _driver.FindElement(By.CssSelector("#js-fullscreen-hero .hero__line"));
            return title.Text;

        }
    }
}
