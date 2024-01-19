using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProject.Drivers;
using TestingProject.PageObjects;

namespace TestingProject.Features.Steps
{
    [Binding]
    public class HchbTestSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private static GoogleSearchPO GoogleSearchPO;
        private static HchbHomePO HchbHomePO;
        private static HchbRequestDemoPO HchbRequestDemoPO;
        private static SeleniumDriver SeleniumDriver;
        private static IWebDriver driver;

        public HchbTestSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            SeleniumDriver ??= _scenarioContext.Get<SeleniumDriver>("SeleniumDriver");
            driver ??= _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Driver;
            GoogleSearchPO = new GoogleSearchPO(SeleniumDriver);
            HchbHomePO = new HchbHomePO(SeleniumDriver);
            HchbRequestDemoPO = new HchbRequestDemoPO(SeleniumDriver);
        }

        [Given(@"the browser is opened in Google homepage")]
        public void GivenTheBrowserIsOpenedInGoogleHomepage()
        {
            GoogleSearchPO.IsDriverRunning();
        }

        [Given(@"I input ""([^""]*)"" on the Google search box")]
        public void GivenIInputOnTheGoogleSearchBox(string text)
        {
            GoogleSearchPO.InsertTextInSearchBox(text);
        }

        [Given(@"I clear the Google search box")]
        public void GivenIClearTheGoogleSearchBox()
        {
            GoogleSearchPO.ClearSearchBox();
        }

        [Given(@"I hit the Google search button")]
        public void GivenIHitTheGoogleSearchButton()
        {
            GoogleSearchPO.ClickOnGoogleSearch();
        }

        [When(@"I select the result with the link ""([^""]*)""")]
        public void WhenISelectTheResultWithTheLink(string link)
        {
            GoogleSearchPO.ClickOnResultContainingLinkWithText(link);
        }

        [Then(@"the page presented contains the URL ""([^""]*)""")]
        public void ThenThePagePresentedContainsTheURL(string pageUrl)
        {
            Assert.Equal(pageUrl, driver.Url);
        }

        [When(@"I click on the button Request Demo")]
        public void WhenIClickOnTheButtonRequestDemo()
        {
            HchbHomePO.ClickOnRequestADemo();
        }

        [When(@"I fill the form with the following information")]
        public void WhenIFillTheFormWithTheFollowingInformation(Table table)
        {
            var info = table.Rows.Select(
                row => new
                {
                    FirstName = row["First Name"],
                    LastName = row["Last Name"],
                    Email = row["Email"],
                    Phone = row["Phone"],
                    Role = row["Role"],
                    Company = row["Company"],
                    City = row["City"],
                    State = row["State"],
                    Census = row["Census"],
                }).First();

            HchbRequestDemoPO.SwitchToIFrame();
            HchbRequestDemoPO.FillForm(info.FirstName, info.LastName, info.Email, info.Phone, info.Role,
            info.Company, info.City, info.State, info.Census);
            HchbRequestDemoPO.SwitchToDefaultContent();
        }

        [When(@"I click on the button Submit")]
        public void WhenIClickOnTheButtonSubmit()
        {
            HchbRequestDemoPO.SwitchToIFrame();
            HchbRequestDemoPO.ClickOnSubmitButton();
            HchbRequestDemoPO.SwitchToDefaultContent();
        }

        [Then(@"the error message ""([^""]*)"" is displayed")]
        public void ThenTheErrorMessageIsDisplayed(string p0)
        {
            HchbRequestDemoPO.SwitchToIFrame();
            Assert.True(HchbRequestDemoPO.IsErrorMessageDisplayed());
            HchbRequestDemoPO.SwitchToDefaultContent();
        }


        [Then(@"the field ""([^""]*)"" contains the error message This field is required")]
        public void ThenTheFieldContainsTheErrorMessageThisFieldIsRequried(string fieldName)
        {
            HchbRequestDemoPO.SwitchToIFrame();
            Assert.True(HchbRequestDemoPO.IsFieldRequiredTextPresent(fieldName));
            HchbRequestDemoPO.SwitchToDefaultContent();
        }

        [Then(@"the Invalid CAPTCHA error message is presented")]
        public void ThenTheInvalidCAPTCHAErrorMessageIsPresented()
        {
            HchbRequestDemoPO.SwitchToIFrame();
            Assert.True(HchbRequestDemoPO.IsInvalidCaptchaMessagePresent());
            HchbRequestDemoPO.SwitchToDefaultContent();
        }
    }
}
