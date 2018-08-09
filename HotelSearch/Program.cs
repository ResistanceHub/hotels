﻿using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace HotelSearch
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const string path = @"C:\dev\hotels\HotelSearch\SearchResult\hotelInfo.csv";
           
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
            Thread.Sleep(TimeSpan.FromSeconds(5));

            //Add the Hotel Names to the list
            var elementsOfHotels = driver.FindElements(By.CssSelector("h3.name__copytext"));
            var hotelNameList = new List<string>();
            for (var i = 0; i <= elementsOfHotels.Count - 1; i++)
            {
                hotelNameList.Add(elementsOfHotels[i].Text);
            }
            driver.Close();//why 
            //Save Hotel Name list on screen or into CSV file
            using (var hotelInfoResults = new StreamWriter(path))
            {  
               Console.WriteLine($"First Page Hotel Name List");
                hotelInfoResults.WriteLine($"First Page Hotel Name List");

                for (var i = 0; i <= elementsOfHotels.Count - 1; i++)
                {
                   Console.WriteLine($"{i + 1},  {hotelNameList[i]}");

                    hotelInfoResults.WriteLine($"{i + 1}, {hotelNameList[i]}");
                }               
            }
         Console.ReadKey();//this need to be at the end of program
        }    
    } 
}


