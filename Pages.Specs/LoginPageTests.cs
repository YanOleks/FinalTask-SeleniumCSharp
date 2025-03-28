using Pages.PageObjects;

namespace Pages.Specs
{    
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Edge)]
    [TestFixture(BrowserType.Firefox)]
    [Parallelizable]
    public class LoginPageTests
    {
        private readonly BrowserType browser;
        private LoginPage loginPage;
        private WebDriverManager driverManager;

        public LoginPageTests(BrowserType browser)
        {
            this.browser = browser;
        }        

        [SetUp]
        public void SetUp()
        {
            driverManager = WebDriverManager.Instance;
            driverManager.InitDriver(this.browser);
            loginPage = new LoginPage(driverManager.GetDriver()!);
        }

        [TearDown]
        public void TearDown()
        {
            driverManager.QuitDriver();
        }

        [TestCaseSource(typeof(LoginPageTestDataProvider), nameof(LoginPageTestDataProvider.GetInvalidUsernameTestData))]
        public void GivenInvalidUsername_WhenLogin_ExpectUsernameErrorMessage(string username, string password, string expectedMessage)
        {
            var message = loginPage.Open()
                .FillForm(username, password)
                .ClearForm()
                .SubmitFormExpectingFailure()
                .GetErrorMessageText();

            Assert.That(message, Does.Contain(expectedMessage));
        }

        [TestCaseSource(typeof(LoginPageTestDataProvider), nameof(LoginPageTestDataProvider.GetInvalidPasswordTestData))]
        public void GivenInvalidPassword_WhenLogin_ExpectPasswordErrorMessage(string username, string password, string expectedMessage)
        {
            var message = loginPage.Open()
                .FillForm(username, password)
                .ClearPasswordInput()
                .SubmitFormExpectingFailure()
                .GetErrorMessageText();

            Assert.That(message, Does.Contain(expectedMessage));
        }

        [TestCaseSource(typeof(LoginPageTestDataProvider), nameof(LoginPageTestDataProvider.GetValidLoginTestData))]
        public void GivenValidCredentials_WhenLogin_ExpectDashboardTitle(string username, string password, string expectedMessage)
        {
            var message = loginPage.Open()
                .FillForm(username, password)
                .SubmitFormExpectingSuccess()
                .GetDashboardTitleText();

            Assert.That(message, Is.EqualTo(expectedMessage));
        }
    }
}
