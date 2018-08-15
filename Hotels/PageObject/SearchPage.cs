using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hotels.Models;

namespace Hotels.PageObject
{
    class SearchPage
    {
        private readonly IWebDriver _driver;
       
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void searchHotel(string cityName)
        {
            IWebElement searchTextbox = _driver.FindElement(By.Id("horus-querytext"));
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            searchTextbox.SendKeys(cityName);
            _driver.FindElement(By.ClassName("horus-btn-search__icon")).Click();
        }

        public void dismissPopups()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until((d) => d.FindElements(By.CssSelector(".df_overlay_close_wrap")));

            _driver.FindElement(By.ClassName("df_overlay_close_wrap")).Click();

        }

        public List<Hotel> GetHotels()
        {
            Console.WriteLine("Entering the hotel details in a short while...");
            var hotels = new List<Hotel>();

            using (StreamWriter sw = new StreamWriter("C:\\src\\hotels\\Hotel_Information.txt"))
            //using (StreamWriter sw = new StreamWriter("@./Hotel_Information.csv"))
            {

                int noOfHotels = 25;
                Thread.Sleep(TimeSpan.FromSeconds(5));
                
                for (int i = 1; i <= noOfHotels; i++)
                {
                    var selectHotelName = _driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > h3")).Text;
                    var selectHotelRating = _driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > span.rating-box__value")).Text;
                    var selectHotelPrice = _driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > strong.item__best-price")).Text;
                    // sw.Write(selectHotelName + " , " + selectHotelRating + " , " + selectHotelPrice + Environment.NewLine);
                    var hotel = new Hotel(selectHotelName, float.Parse(selectHotelRating), selectHotelPrice);
                    hotels.Add(hotel);
                }

                Console.WriteLine("All Hotel details has been written...Congratulations!!!");
            }
            return hotels;



        }

    }
}
