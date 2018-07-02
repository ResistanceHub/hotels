using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HotelSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //search with the hotel names in London area
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trivago.co.uk");
            driver.FindElement(By.Id("horus-querytext")).SendKeys("London");
            driver.FindElement(By.ClassName("horus-btn-search")).Click();// how do I know need to find element by classname and how to decide the content 'horus-btn-search' as the class said that it is 'btn btn--primary horus-btn-search'?
            Thread.Sleep(1000);//to delay to allow the popup happen
            driver.FindElement(By.ClassName("df_overlay_close_wrap")).Click();//dismiss popups

            


            //save all searched result to the list
            //var ListOfHotels = driver.FindElements(By.CssSelector("h3"));
            //for (int i = 0; i <= 15; i++)
            //{

            //}

            Console.ReadKey();
        }
    }
}
