using BoDi;
using OpenQA.Selenium;
using SauceDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemo.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;

        protected Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario(Order = 0)]
        public void BrowserSetup()
        {
            var driver = Driver.CreateBrowserSession();
            _container.RegisterInstanceAs(driver);
        }

        [AfterScenario(Order = 99)]
        public void BrowserTearDown()
        {
            _container.Resolve<IWebDriver>().Dispose();
        }
    }
}

