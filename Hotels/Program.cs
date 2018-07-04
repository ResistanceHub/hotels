﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trivago.co.uk/");
            IWebElement city = driver.FindElement(By.Id("horus-querytext"));
            city.SendKeys("London");
            driver.FindElement(By.ClassName("horus-btn-search__icon")).Click(); //Click Search button
            //driver.FindElement(By.CssSelector("#js-fullscreen-hero > div > form > div.df_overlay > div.df_overlay_title > button")).Click(); //close unwanted Check-in Date popup

            Console.WriteLine("Started to write to the file. Please wait...");         
            using (StreamWriter sw = new StreamWriter("C:\\dev\\hotels\\Hotel Information.txt"))
            {
                int noOfHotelsPerPage = 25;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(6));
                for (int i = 1; i <= noOfHotelsPerPage; i++)
                {
                    var hotelName = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-Child(" + i + ") div > h3")).Text;
                    var rating = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-Child(" + i + ") div span.rating-box__value")).Text;
                    sw.Write(hotelName + "," + rating + Environment.NewLine);
                }
            }
            Console.WriteLine("Finished writing to the file. You can open it from here => C:\\dev\\hotels\\Hotel Information.txt");
            Console.ReadKey();
        }
    }
}


