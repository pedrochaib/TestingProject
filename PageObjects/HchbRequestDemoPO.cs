using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.Network;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProject.Drivers;

namespace TestingProject.PageObjects
{
    public class HchbRequestDemoPO : BasePage
    {
        private readonly By _firstNameInputByXPath;
        private readonly By _lastNameInputByXPath;
        private readonly By _emailInputByXPath;
        private readonly By _phoneInputByXPath;
        private readonly By _roleBoxByXPath;
        private readonly By _companyInputByXPath;
        private readonly By _cityInputByXPath;
        private readonly By _stateBoxByXPath;
        private readonly By _censusBoxByXPath;
        private readonly By _submitButtonByXPath;
        private readonly By _iFrameFormByXPath;

        public HchbRequestDemoPO(SeleniumDriver driver) : base(driver)
        {
            this.driver = driver.Driver;
            _firstNameInputByXPath = By.XPath("//label[text() = 'First Name *']/following-sibling::input");
            _lastNameInputByXPath = By.XPath("//label[text() = 'Last Name *']/following-sibling::input");
            _emailInputByXPath = By.XPath("//label[text() = 'Email *']/following-sibling::input");
            _phoneInputByXPath = By.XPath("//label[text() = 'Phone *']/following-sibling::input");
            _roleBoxByXPath = By.XPath("//label[text() = 'Role *']/following-sibling::select");
            _companyInputByXPath = By.XPath("//label[text() = 'Company *']/following-sibling::input");
            _cityInputByXPath = By.XPath("//label[text() = 'City *']/following-sibling::input");
            _stateBoxByXPath = By.XPath("//label[text() = 'State *']/following-sibling::select");
            _censusBoxByXPath = By.XPath("//label[text() = 'Census']/following-sibling::select");
            _submitButtonByXPath = By.XPath("//input[@type = 'submit']");
            _iFrameFormByXPath = By.XPath("//iframe[@class= 'pardotform']");
        }

        public void FillForm(string firstName, string lastName, string email, string phone,
            string role, string company, string city, string state, string census)
        {
            FillFirstName(firstName).
            FillLastName(lastName).
            FillEmail(email).
            FillPhone(phone).
            SelectRole(role).
            FillCompany(company).
            FillCity(city).
            SelectState(state).
            SelectCensus(census);
        }

        private HchbRequestDemoPO FillFirstName(string firstName)
        {
            driver.FindElement(_firstNameInputByXPath).SendKeys(firstName);
            return this;
        }

        private HchbRequestDemoPO FillLastName(string lastName)
        {
            driver.FindElement(_lastNameInputByXPath).SendKeys(lastName);
            return this;
        }

        private HchbRequestDemoPO FillEmail(string email)
        {
            driver.FindElement(_emailInputByXPath).SendKeys(email);
            return this;
        }

        private HchbRequestDemoPO FillPhone(string phone)
        {
            driver.FindElement(_phoneInputByXPath).SendKeys(phone);
            return this;
        }

        private HchbRequestDemoPO SelectRole(string role)
        {
            driver.FindElement(_roleBoxByXPath).Click();
            var optionList = driver.FindElement(_roleBoxByXPath).FindElements(By.TagName("option"));
            optionList.First(x => x.Text == role).Click();
            return this;
        }

        private HchbRequestDemoPO FillCompany(string company)
        {
            driver.FindElement(_companyInputByXPath).SendKeys(company);
            return this;
        }

        private HchbRequestDemoPO FillCity(string city)
        {
            driver.FindElement(_cityInputByXPath).SendKeys(city);
            return this;
        }

        private HchbRequestDemoPO SelectState(string state)
        {
            driver.FindElement(_stateBoxByXPath).Click();
            var stateList = driver.FindElement(_stateBoxByXPath).FindElements(By.TagName("option"));
            stateList.First(x => x.Text == state).Click();
            return this;
        }

        private HchbRequestDemoPO SelectCensus(string census)
        {
            if (census != null)
            {
                driver.FindElement(_censusBoxByXPath).Click();
                var censusList = driver.FindElement(_stateBoxByXPath).FindElements(By.TagName("option"));
                censusList.First(x => x.Text == census).Click();
            }

            return this;
        }

        public void ClickOnSubmitButton()
        {
            driver.FindElement(_submitButtonByXPath).Click();
        }

        public bool IsErrorMessageDisplayed()
        {
            return Wait.Until(ExpectedConditions
                .ElementExists(
                By.XPath("//p[text() = 'Please correct the errors below:']"))).Displayed;
        }

        public bool IsFieldRequiredTextPresent(string fieldName)
        {
            var xpath = $"//p[contains(@class, '{fieldName}')]//following-sibling::p[1][text() = 'This field is required']";
            return Wait.Until(ExpectedConditions.
                ElementExists(By
                .XPath(xpath))).Displayed;
        }

        public bool IsInvalidCaptchaMessagePresent()
        {
            return Wait.Until(ExpectedConditions
                .ElementExists(By.XPath("//p[text() = 'Invalid CAPTCHA']"))).Displayed;
        }

        public void SwitchToIFrame()
        {
            var iFrameForm = driver.FindElement(By.XPath("//iframe[@class= 'pardotform']"));
            iFrameForm.Click();
            driver.SwitchTo().Frame(iFrameForm);
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
