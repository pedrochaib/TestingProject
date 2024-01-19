using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProject.Drivers;

namespace TestingProject.Hooks
{
    [Binding]
    public class Hooks
    {
        private static SeleniumDriver? driver;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var chromeOptions = new ChromeOptions();

            if (driver == null)
            {
                driver = new SeleniumDriver(_scenarioContext);
                driver.Initialize(chromeOptions);
                _scenarioContext.Add("SeleniumDriver", driver);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Dispose();
        }
    }
}
