using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.Support.UI;

namespace HotelSearch
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //search with the hotel names in London area
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trivago.co.uk");
            var city = driver.FindElement(By.Id("horus-querytext"));
            if (city == null) throw new ArgumentNullException(nameof(city));
            city.SendKeys("London");

            driver.FindElement(By.ClassName("horus-btn-search")).Click();//click seearch button

            //dismiss popups
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.ClassName("df_overlay_close_wrap"))).Click();


            Thread.Sleep(TimeSpan.FromSeconds(5));

            //Add the Hotel Name search result to the list
            var elementsOfHotels = driver.FindElements(By.CssSelector("h3.name__copytext")); 
            var hotelNameList = new List<string>();
            for (var i = 0; i <= elementsOfHotels.Count-1; i++)
            {
                hotelNameList.Add(elementsOfHotels[i].Text);
            }

            //Save the search list on console / to CSV file
            for (var i = 0; i <= elementsOfHotels.Count - 1; i++)
            {
                Console.WriteLine($"{i + 1}:  {hotelNameList[i]}");

            }

            Console.ReadKey();
            }
        }
    }




