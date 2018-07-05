using OpenQA.Selenium;
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
        static IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
            LoadUrl("https://www.trivago.co.uk/");
            SearchHotels("London");                                  
            WriteToFile();            
        }
        public static void LoadUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void SearchHotels(string city)
        {
            IWebElement cityElement = driver.FindElement(By.Id("horus-querytext"));
            cityElement.SendKeys(city);
            driver.FindElement(By.ClassName("horus-btn-search__icon")).Click(); //Click Search button
        }
        public static void WriteToFile()
        {
            Console.WriteLine("Started to write to the file. Please wait...");
            using (StreamWriter sw = new StreamWriter("C:\\dev\\hotels\\Hotel Information.txt"))
            {
                
                int noOfHotelsPerPage = 25;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(7));
                for (int i = 1; i <= noOfHotelsPerPage; i++)
                {
                    var hotelName = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-Child(" + i + ") div > h3")).Text;
                    var rating = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-Child(" + i + ") div span.rating-box__value")).Text;
                    var price = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-Child(" + i + ") div.strikethough__wrapper .item__best-price")).Text;
                    sw.Write(hotelName + "," + rating + "," + price + Environment.NewLine);
                }

            }
            Console.WriteLine("Finished writing to the file. You can open it from here => C:\\dev\\hotels\\Hotel Information.txt");
            Console.ReadKey();
        }
        public static void readFromFile()
        {
            using (StreamWriter sw = new StreamWriter("C:\\dev\\hotels\\Hotel Information.txt"))
            {

            }
        }
    }
}


