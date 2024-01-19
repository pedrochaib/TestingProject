using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProject.Drivers;

namespace TestingProject.PageObjects
{
    public class HchbHomePO : BasePage
    {
        private readonly By _requestADemoByXPath;

        public HchbHomePO(SeleniumDriver driver) : base(driver)
        {
            this.driver = driver.Driver;

            _requestADemoByXPath = By.XPath("(//span[text()='Request a Demo'])[2]");
        }

        public bool DoesPhoneNumberMatch(string phoneNumber)
        {
            var xpath = $"//ul/li/a[@href='tel:{phoneNumber}']";
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath))).Displayed;
        }

        public bool DoesEmailMatch(string email)
        {
            var xpath = $"//ul/li/a[@href='mailto:{email}']";
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath))).Displayed;
        }

        public void ClickOnRequestADemo()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_requestADemoByXPath)).Click();
        }
    }
}
