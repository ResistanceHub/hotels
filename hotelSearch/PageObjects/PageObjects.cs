using System;
using HotelSearch.PageObjects;
using OpenQA.Selenium;

//parent of all page objects
namespace HotelSearch.PageObjects
{
    public class PageObjects
    {
        protected readonly IWebDriver _driver;  // 'protected' -it is accessible within its class and by derived class instances.
        
        //private readonly string _url;
        public PageObjects (IWebDriver driver) //base contructor to initilise the each instance of child class 
        {
            _driver = driver;         
        }
    }
}