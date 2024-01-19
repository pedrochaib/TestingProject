using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestingProject.Drivers;
using static System.Net.Mime.MediaTypeNames;

namespace TestingProject.PageObjects
{
    public class GoogleSearchPO : BasePage
    {
        private readonly By _searchTextAreaByXPath;
        private readonly By _searchButtonByXPath;

        public GoogleSearchPO(SeleniumDriver driver) : base(driver)
        {
            this.driver = driver.Driver;

            _searchTextAreaByXPath = By.XPath("//textarea[@type='search']");
            _searchButtonByXPath = By.XPath("(//input[@type = 'submit'][@role= 'button'])[2]");
        }

        public GoogleSearchPO InsertTextInSearchBox(string text)
        {
            if (IsElementVisible(_searchTextAreaByXPath))
            {
                driver.FindElement(_searchTextAreaByXPath).SendKeys(text);
            }

            return this;
        }

        public GoogleSearchPO ClearSearchBox()
        {
            if (IsElementVisible(_searchTextAreaByXPath))
            {
                driver.FindElement(_searchTextAreaByXPath).SendKeys(Keys.Control + "a");
                driver.FindElement(_searchTextAreaByXPath).SendKeys(Keys.Delete);
            }

            return this;
        }

        public void ClickOnGoogleSearch()
        {
            driver.ExecuteJavaScript("arguments[0].click();", driver.FindElement(_searchButtonByXPath));
        }

        public List<IWebElement> ResultListFromSearch()
        {
            return driver.FindElements(By.TagName("h3")).ToList();
        }

        public void ClickOnResultContainingLinkWithText(string textLink)
        {
            driver.FindElement(By.TagName("h3"))
                .FindElement(By.XPath($"//a[contains(@href, '{textLink}')]")).Click();
        }
    }
}
