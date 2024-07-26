using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceDemo
{
    [Binding]
    public static class Driver
    {
       // private WebDriver driver;
        public static IWebDriver CreateBrowserSession()
        {
            //new DriverManager().SetUpDriver(new ChromeConfig());
            //var driver = new ChromeDriver();

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig()); //, version: "126.0.6478.128");
            ChromeDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
