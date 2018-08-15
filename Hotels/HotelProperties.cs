using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace Hotels
{
    class HotelProperties
    {
        
        private readonly IWebDriver _driver;
        public HotelProperties(IWebDriver driver)
        {
            _driver = driver;
        }
        public void searchHotel(string cityName)
        {
            IWebElement searchTextbox = _driver.FindElement(By.Id("horus-querytext"));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            searchTextbox.SendKeys(cityName);
            _driver.FindElement(By.ClassName("horus-btn-search__icon")).Click();
        }

        public void writeToFile()
        {
            Console.WriteLine("Entering the hotel details in a short while...");

            using (StreamWriter sw = new StreamWriter("C:\\src\\hotels\\Hotel_Information.txt"))
            {

                int noOfHotels = 25;
                Thread.Sleep(TimeSpan.FromSeconds(5));

                for (int i = 1; i <= noOfHotels; i++)
                {
                    var selectHotelName = _driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > h3")).Text;
                    var selectHotelRating = _driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > span.rating-box__value")).Text;
                    var selectHotelPrice = _driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > strong.item__best-price")).Text;
                    sw.Write(selectHotelName + " , " + selectHotelRating + " , " + selectHotelPrice + Environment.NewLine);
                }

                Console.WriteLine("All Hotel details has been written...Congratulations!!!");
            }


        }



    }
}
