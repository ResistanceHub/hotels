using System;
using OpenQA.Selenium.Chrome;
using HotelSearch.PageObjects;

namespace HotelSearch
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            var homePage = new HomePage(driver);
            homePage.Navigate("https://www.trivago.co.uk");
            homePage.SearchItem("London");
            var searchPage = new SearchPage(driver);
            searchPage.DismissPopUps();
            var hotels = searchPage.GetHotels();
            var path = @"..\..\SearchResult\hotels.csv"; //put reltive path to Debug folder
            var dataStore = new DataStore(path);
            dataStore.SaveHotels(hotels);
            driver.Close(); // to close web application         
            Console.ReadKey(); //To keep the result on screen 
        }
    }
}
    




