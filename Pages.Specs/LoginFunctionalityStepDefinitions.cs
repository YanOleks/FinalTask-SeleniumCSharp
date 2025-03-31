using System;
using OpenQA.Selenium;
using Pages.PageObjects;
using Reqnroll;

namespace Pages.Specs
{
    [Binding]
    public class LoginFunctionalityStepDefinitions
    {
        private IWebDriver? driver;
        private BrowserType browserType = BrowserType.Chrome; // Значення за замовчуванням
        private readonly Lazy<LoginPage> loginPage;
        private MainPage? mainPage;

        public LoginFunctionalityStepDefinitions()
        {
            loginPage = new Lazy<LoginPage>(() => new LoginPage(driver ?? throw new InvalidOperationException("Driver not initialized")));
        }

        [Given("I use {string} browser")]
        public void GivenIUseBrowser(BrowserType browser)
        {
            browserType = browser;
            driver = WebDriverManager.Instance.InitDriver(browserType);
        }

        [Given(@"I opened the Login page")]
        public void GivenIOpenTheLoginPage()
        {
            if (driver == null)
            {
                throw new InvalidOperationException("WebDriver is not initialized. Ensure you have set the browser type before opening the page.");
            }

            loginPage.Value.Open();
        }

        [Given(@"I entered {string} as username")]
        public void WhenIEnterAsUsername(string username)
        {
            loginPage.Value.FillUsername(username);
        }

        [Given(@"I entered {string} as password")]
        public void WhenIEnterAsPassword(string password)
        {
            loginPage.Value.FillPassword(password);
        }

        [Given(@"I cleared both inputs")]
        public void WhenIClearBothInputs()
        {
            loginPage.Value.ClearForm();
        }

        [Given(@"I cleared the Password input")]
        public void WhenIClearThePasswordInput()
        {
            loginPage.Value.ClearPasswordInput();
        }

        [When(@"I click the Login button with invalid input")]
        public void WhenIClickTheLoginButtonExpectinFailure()
        {
            loginPage.Value.SubmitFormExpectingFailure();
        }

        [When(@"I click the Login button with valid input")]
        public void WhenIClickTheLoginButtonExpectingSuccess()
        {
            mainPage = loginPage.Value.SubmitFormExpectingSuccess();
        }

        [Then(@"I should see the error message {string}")]
        public void ThenIShouldSeeTheErrorMessage(string expectedMessage)
        {
            var actualErrorMessage = loginPage.Value.GetErrorMessageText();
            Assert.That(actualErrorMessage, Does.Contain(expectedMessage));
        }

        [Then(@"I should see the dashboard title {string}")]
        public void ThenIShouldSeeTheDashboardTitle(string expectedTitle)
        {            
            var actualDashboardTitle = mainPage!.GetDashboardTitleText();
            Assert.That(actualDashboardTitle, Is.EqualTo(expectedTitle));
        }
    }
}
