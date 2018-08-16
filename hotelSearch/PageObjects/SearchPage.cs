using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HotelSearch.PageObjects
{
    class SearchPage
    {
        private readonly IWebDriver _driver;
        public SearchPage(IWebDriver driver) //constructor to assign the Web driver once for all method on the Seach page
        {
            _driver = driver; //make private to public
        }
        public void DismissPopUps()
        {
            //dismiss PopUps       
            var wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait1.Until(drv => drv.FindElement(By.ClassName("overlay__close")));
           _driver.FindElement(By.ClassName("overlay__close")).Click();//popup1

            var wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait2.Until(drv => drv.FindElement(By.ClassName("refinement-row__btn")));
            _driver.FindElement(By.ClassName("refinement-row__btn")).Click(); //popup2

            Thread.Sleep(TimeSpan.FromSeconds(7)); //wait until result show up
        }
        public List<Hotel> GetHotels() //return Type needed
        {
            //Add the Hotel's informations to the list
            var elementsOfHotels =
                _driver.FindElements(By.ClassName("hotel")); //find parent node to cover all info we need
            // create hotels using LINQ select
            var hotels = elementsOfHotels.Select(hotelElement => {
                var name = hotelElement.FindElement(By.CssSelector(".name__copytext")).Text;
                var rating = hotelElement.FindElement(By.ClassName("rating-box__value")).Text;
                var price = hotelElement.FindElement(By.ClassName("item__best-price")).Text;
                return new Hotel(name, rating, price);
            }).ToList();

            return hotels;
        }
        public void SaveHotels(List<Hotel> hotels)
        {
            //Save Hotel Name list on screen or into CSV file
            const string path = @"..\..\SearchResult\hotels.csv"; //put reltive path to Debug folder           
            for (var i = 0; i <= hotels.Count - 1; i++)
            {
                var hotel = hotels[i];
                Console.WriteLine($"{i + 1},{hotel.Name}, {hotel.Rating},{hotel.Price}");
            }           
            var fs = new FileStream(path, FileMode.Create);
            using (var hotelsResult = new StreamWriter(fs, Encoding.UTF8)
            ) // Get correct encoding format for price, see https://msdn.microsoft.com/en-us/library/72d9f8d5(v=vs.110).aspx
            {
                Console.WriteLine("First Page Hotels");
                Console.WriteLine($"{"ID"}, {"Name"} , {"Rating"} , {"Price"}");

                hotelsResult.WriteLine("First Page Hotels");
                hotelsResult.WriteLine($"{"ID"}, {"Name"} , {"Rating"} , {"Price"}");

                for (var i = 0; i < hotels.Count; i++) {
                    Hotel hotel = hotels[i];
                    Console.WriteLine($"{i + 1},{hotel.Name}, {hotel.Rating},{hotel.Price}");
                    hotelsResult.WriteLine($"{i + 1},{hotel.Name},{hotel.Rating},{hotel.Price}");
                }

            }
        }
    }
}
