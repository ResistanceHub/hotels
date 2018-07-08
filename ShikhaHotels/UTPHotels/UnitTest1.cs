using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;


namespace UTPHotels
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
               
            
                List<string> hoteList = new List<String>();
                var hotel = new ChromeDriver();
                
                hotel.Navigate().GoToUrl("https://www.trivago.co.uk");

                hotel.FindElementById("horus-querytext").SendKeys("London");
                hotel.FindElementByClassName("horus-btn-search__label").Click();
                Thread.Sleep(3000);
            //IWebElement element = hotel.FindElement(By.CssSelector("h3.name__copytext"));
            var hotelLi = hotel.FindElements(By.CssSelector("h3.name__copytext"));
            int i = hotelLi.Count;
            string j = Convert.ToString(i);

            
            foreach (var VARIABLE in hotelLi)
            {
                
              hoteList.Add(VARIABLE.Text);
                
            }

            using (TextWriter tw = new StreamWriter("HotelNames.txt"))
            {
                foreach (var s in hoteList)
                {
                    tw.WriteLine(s);
                }
            }


        }
    }
}
