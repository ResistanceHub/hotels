using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public class Hotel
        {
            // these are private fields
            private String _name;
            private String _rating;
            private String _price;

            // this is a public property
            public string Name => _name;
            public string Rating => _rating;
            public string Price => _price;

            public Hotel(string name, string rating, string price)
            {
                _name = name;
                _rating = rating;
                _price = price;
            }


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
    }
}
