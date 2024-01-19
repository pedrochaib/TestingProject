using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject.Drivers
{
    public class SeleniumDriver : IDisposable
    {
        private readonly ScenarioContext _scenarioContext;
        public IWebDriver Driver { get; private set; }

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Initialize(ChromeOptions chromeOptions)
        {
            Driver ??= new ChromeDriver(chromeOptions);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.Navigate().GoToUrl("http://google.com/");
            return Driver;
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
