using System;
using Pages.PageObjects;
using Reqnroll;

namespace Pages.Specs
{
    [Binding]
    public class LoginFunctionalityStepDefinitions
    {
        private readonly LoginPage loginPage;
        private MainPage? mainPage = null;

        public LoginFunctionalityStepDefinitions()
        {
            var driver = WebDriverManager.Instance
                .InitDriver(BrowserType.Chrome);
            loginPage = new LoginPage(driver);
        }

        [Given(@"I opened the Login page")]
        public void GivenIOpenTheLoginPage()
        {
            loginPage.Open();
        }

        [Given(@"I entered ""(.*)"" as username")]
        public void WhenIEnterAsUsername(string username)
        {
            loginPage.FillUsername(username);
        }

        [Given(@"I entered ""(.*)"" as password")]
        public void WhenIEnterAsPassword(string password)
        {
            loginPage.FillPassword(password);
        }

        [Given(@"I cleared both inputs")]
        public void WhenIClearBothInputs()
        {
            loginPage.ClearForm();
        }

        [Given(@"I cleared the Password input")]
        public void WhenIClearThePasswordInput()
        {
            loginPage.ClearPasswordInput();
        }

        [When(@"I click the Login button with invalid input")]
        public void WhenIClickTheLoginButtonExpectinFailure()
        {
            loginPage.SubmitFormExpectingFailure();
        }

        [When(@"I click the Login button with valid input")]
        public void WhenIClickTheLoginButtonExpectingSuccess()
        {
            mainPage = loginPage.SubmitFormExpectingSuccess();
        }

        [Then(@"I should see the error message ""(.*)""")]
        public void ThenIShouldSeeTheErrorMessage(string expectedMessage)
        {
            var actualErrorMessage = loginPage.GetErrorMessageText();
            Assert.That(actualErrorMessage, Does.Contain(expectedMessage));
        }

        [Then(@"I should see the dashboard title ""(.*)""")]
        public void ThenIShouldSeeTheDashboardTitle(string expectedTitle)
        {
            var actualDashboardTitle = mainPage!.GetDashboardTitleText();
            Assert.That(actualDashboardTitle, Is.EqualTo(expectedTitle));
        }
    }
}
