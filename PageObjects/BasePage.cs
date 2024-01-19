using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProject.Drivers;

namespace TestingProject.PageObjects
{
    public abstract class BasePage
    {
        public IWebDriver driver;
        public WebDriverWait Wait;

        public BasePage(SeleniumDriver driver)
        {
            this.driver = driver.Driver;
            Wait ??= new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
        }

        public bool IsDriverRunning()
        {
            return driver.WindowHandles.Count > 0;
        }

        public bool IsElementVisible(By by)
        {
            return Wait.Until(ExpectedConditions.ElementExists(by)).Displayed;
        }
    }
}
