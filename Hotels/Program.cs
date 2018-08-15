using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Hotels.PageObject;
using Hotels.DataStorage;

namespace Hotels
{
    class Program
    {
        static IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {                      
            var HomePage = new HomePage(driver);
            HomePage.Navigate();

            var SearchPage = new SearchPage(driver);
            SearchPage.searchHotel("London");

            SearchPage.dismissPopups();
            var hotels = SearchPage.GetHotels();
               
            var path = "C:\\src\\hotels\\Hotel_Information.txt";
            var fileWriter = new FileWriter(path);
            fileWriter.SaveHotels(hotels);
                    
            Console.ReadKey();
            driver.Close();
        }         
              

    }
}
