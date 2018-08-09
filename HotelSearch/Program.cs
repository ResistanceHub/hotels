using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace HotelSearch
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const string path = @"C:\dev\hotels\HotelSearch\SearchResult\hotels.csv";

            //search with the hotel names in London area
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trivago.co.uk");
            var city = driver.FindElement(By.Id("horus-querytext"));
            if (city == null) throw new ArgumentNullException(nameof(city));
            city.SendKeys("London");

            driver.FindElement(By.ClassName("horus-btn-search")).Click(); //click search button

            //dismiss popups
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElement(By.ClassName("df_overlay_close_wrap"))).Click();
            Thread.Sleep(TimeSpan.FromSeconds(7));

            //Add the HotelInfo to the list
            var elementsOfHotels = driver.FindElements(By.ClassName("hotel"));//find parent node to cover all info we need

            var hotels = new List<Hotel>();

            //create hotels list using a for loop
            //for (var i = 0; i <= elementsOfHotels.Count - 1; i++)
            //        {
            //            var name = elementsOfHotels[i].FindElement(By.CssSelector(".name__copytext")).Text;//CssSelector need .
            //            var rating = elementsOfHotels[i].FindElement(By.ClassName("rating-box__value")).Text;//Class don't need .
            //            var price = elementsOfHotels[i].FindElement(By.ClassName("item__best-price")).Text;
            //            var hotel = new Hotel(name, rating, price);
            //            hotels.Add(hotel);
            //        }

            //// create hotels using LINQ select
            hotels = elementsOfHotels.Select(hotelElement =>
            {
                var name = hotelElement.FindElement(By.CssSelector(".name__copytext")).Text;//CssSelector need .
                var rating = hotelElement.FindElement(By.ClassName("rating-box__value")).Text;//Class don't need .
                var price = hotelElement.FindElement(By.ClassName("item__best-price")).Text;
                return new Hotel(name, rating, price);
            }).ToList();

            driver.Close();//why 

            for (var i = 0; i <= hotels.Count - 1; i++)
            {
                var hotel = hotels[i];
                Console.WriteLine($"{i+1},{hotel.Name}, {hotel.Rating},{hotel.Price}");
            }



            //Save Hotel Name list on screen or into CSV file

            using (var hotelsList = new StreamWriter(path))
            {
                Console.WriteLine("First Page Hotels List");
                hotelsList.WriteLine("First Page Hotels List");
                //hotelsList.WriteLine($"Name" + "Rating" + "Price");

                for (var i = 0; i <= hotels.Count - 1; i++)
                {
                    var hotel = hotels[i];

                    Console.WriteLine($"{i + 1},{hotel.Name}, {hotel.Rating},{hotel.Price}");

                    hotelsList.WriteLine($"{i + 1},{hotel.Name},{hotel.Rating},{hotel.Price}");
                }
            }
            Console.ReadKey();//this need to be at the end of program
        }
    }
}



