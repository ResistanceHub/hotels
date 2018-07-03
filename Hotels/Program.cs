using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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
            driver.FindElement(By.ClassName("horus-btn-search__icon")).Click();
            //driver.FindElement(By.ClassName("df_overlay_close_wrap overlay__close")).Click();


            for(int i = 1; i <=25; i++)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
                var hotelName = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-Child(" + i + ") div > h3")).Text;
                var rating = driver.FindElement(By.CssSelector("#js_item_list_container > section > ol > li:nth-Child(" + i + ") div span.rating-box__value")).Text;
                Console.WriteLine(hotelName + ", " + rating);
            }
            Console.ReadKey();
      


        }
    }
}

