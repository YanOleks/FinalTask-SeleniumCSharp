using OpenQA.Selenium;

namespace Pages.PageObjects
{
    public class LoginPage(IWebDriver driver) : BasePage(driver)
    {        
        private static string Url { get; } = @"https://www.saucedemo.com/";

        private Lazy<IWebElement> UsernameInput => new(() => WaitForElementToBeClickable(By.Id("user-name")));
        private Lazy<IWebElement> PasswordInput => new(() => WaitForElementToBeClickable(By.Id("password")));
        private Lazy<IWebElement> LoginButton => new(() => WaitForElementToBeClickable(By.Id("login-button")));
        private Lazy<IWebElement> ErrorMessage => new(() => WaitForElementToBeVisible(By.CssSelector("div.error-message-container.error > h3")));

        public LoginPage Open()
        {
            driver.Url = Url;
            return this;
        }

        public LoginPage FillForm(string username, string password)
        {
            return FillUsername(username).FillPassword(password);
        }

        public LoginPage ClearForm()
        {
            return ClearUsernameInput().ClearPasswordInput();
        }

        public LoginPage FillUsername(string username)
        {
            UsernameInput.Value.SendKeys(username);
            return this;
        }

        public LoginPage ClearUsernameInput()
        {
            UsernameInput.Value.SendKeys(Keys.Control + "a" + Keys.Delete);
            return this;
        }

        public LoginPage FillPassword(string password)
        {
            PasswordInput.Value.SendKeys(password);
            return this;
        }

        public LoginPage ClearPasswordInput()
        {
            PasswordInput.Value.SendKeys(Keys.Control + "a" + Keys.Delete);
            return this;
        }

        public LoginPage SubmitFormExpectingFailure()
        {
            LoginButton.Value.Click();
            return this;
        }

        public MainPage SubmitFormExpectingSuccess()
        {
            LoginButton.Value.Click();
            return new MainPage(driver);
        }

        public string? GetErrorMessageText()
        {
            return ErrorMessage.Value.Text;
        }
    }
}
