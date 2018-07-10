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
            //driver.Close();
        }
        public static void searchHotel()
        {
            IWebElement searchTextbox = driver.FindElement(By.Id("horus-querytext"));
            searchTextbox.SendKeys("London");
            driver.FindElement(By.ClassName("horus-btn-search__icon")).Click();
        }

        public static void dismissPopups()
        {
            //To dismiss popups
            Thread.Sleep(TimeSpan.FromSeconds(5));
            IWebElement closePopup = driver.FindElement(By.ClassName("df_overlay_close_wrap"));
            closePopup.Click();

        }

        public static void writeToFile()
        {
            //Console.WriteLine("Entering the hotel details in a short while");
            //var selectHotelName = driver.FindElements(By.ClassName("h3.name__copytext"));

            //for (int i=1; i<=25; i++)
            //{
            //    Thread.Sleep(TimeSpan.FromSeconds(6));
            //    var selectHotelName = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > h3")).Text;
            //    Console.WriteLine(selectHotelName);
            //}
            Console.WriteLine("Entering the hotel details in a short while...");

            using (StreamWriter sw = new StreamWriter("C:\\src\\hotels\\Hotel_Information.txt"))
            {

                int noOfHotels = 25;
                Thread.Sleep(TimeSpan.FromSeconds(5));

                for (int i = 1; i <= noOfHotels; i++)
                {
                    var selectHotelName = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-child(" + i + ") div > h3")).Text;
                    sw.Write(selectHotelName + Environment.NewLine);
                }

                Console.WriteLine("All Hotel name has been written...Congratulations!!!");
            }

            Console.ReadKey();
        }

    }
}
