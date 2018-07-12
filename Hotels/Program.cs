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
    class Program
    {
        static IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
            driver.Url = "https://www.trivago.co.uk";
            searchHotel();
            //dismissPopups();
            writeToFile();
            Console.ReadKey();
            driver.Close();
        }
        public static void searchHotel()
        {
            IWebElement searchTextbox = driver.FindElement(By.Id("horus-querytext"));
            searchTextbox.SendKeys("London");
            driver.FindElement(By.ClassName("horus-btn-search__icon")).Click();
        }

        public static void dismissPopups()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            IWebElement closePopup = driver.FindElement(By.ClassName("df_overlay_close_wrap"));
            closePopup.Click();

        }

        public static void writeToFile()
        {
            Console.WriteLine("Entering the hotel details in a short while...");

            using (StreamWriter sw = new StreamWriter("C:\\src\\hotels\\Hotel_Information.txt"))
            {

                int noOfHotels = 25;
                Thread.Sleep(TimeSpan.FromSeconds(5));

                for (int i = 1; i <= noOfHotels; i++)
                {
                    var selectHotelName = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > h3")).Text;
                    var selectHotelRating = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > span.rating-box__value")).Text;
                    var selectHotelPrice = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > strong.item__best-price")).Text;
                    sw.Write(selectHotelName + " , " + selectHotelRating + " , "+ selectHotelPrice + Environment.NewLine);
                }

                Console.WriteLine("All Hotel details has been written...Congratulations!!!");
            }

            
        }

    }
}
