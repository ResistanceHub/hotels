using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Collections.Generic;

namespace UnitTestProject1
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
            foreach (int iElement in hotel.FindElementByCssSelector("#js_itemlist > li:nth-child(1)"))
            {
                 hoteList.add = hotel.FindElementByCssSelector("h3.name__copytext").text;
            }

            foreach (var VARIABLE in hoteList)
            {
                Console.Writeline(VARIABLE);
            }

            Console.readkey();







        }
    }
}
