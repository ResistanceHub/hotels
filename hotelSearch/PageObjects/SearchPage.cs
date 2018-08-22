using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HotelSearch.DataTransferObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HotelSearch.PageObjects
{
    public class SearchPage : PageObjects
    {
       
        public SearchPage(IWebDriver driver) : base (driver)//inheritance driver in PageObjects and assign to all methods on this page
        {
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

        public List<HotelDto> GetHotels() //return Type needed
        {
            //Add the HotelDTO's informations to the list
            var elementsOfHotels =
                _driver.FindElements(By.ClassName("hotel")); //find parent node to cover all info we need
            // create hotels using LINQ select
            var hotels = elementsOfHotels.Select(hotelElement => {
                var name = hotelElement.FindElement(By.CssSelector(".name__copytext")).Text;
                var rating = hotelElement.FindElement(By.ClassName("rating-box__value")).Text;
                var price = hotelElement.FindElement(By.ClassName("item__best-price")).Text;
                return new HotelDto(name, rating, price);           
            }).ToList();

            return hotels;
        }
    }
}
