using OpenQA.Selenium;

namespace Pages.PageObjects
{
    public class LoginPage(IWebDriver driver) : BasePage(driver)
    {        
        private static string Url { get; } = @"https://www.saucedemo.com/";

        private IWebElement UsernameInput => driver.FindElement(By.Id("user-name"));

        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));

        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        private IWebElement ErrorMessage => driver.FindElement(By.CssSelector("div.error-message-container.error > h3"));

        public LoginPage Open()
        {
            driver.Url = Url;
            return this;
        }

        public LoginPage FillForm(string username, string password)
        {
            FillUsername(username);
            FillPassword(password);
            return this;
        }

        public LoginPage ClearForm()
        {
            ClearUsernameInput();
            ClearPasswordInput();
            return this;
        }

        public LoginPage FillUsername(string username)
        {
            UsernameInput.SendKeys(username);
            return this;
        }

        public LoginPage ClearUsernameInput()
        {
            UsernameInput.SendKeys(Keys.Control + "a" + Keys.Delete);
            return this;
        }

        public LoginPage FillPassword(string password)
        {
            PasswordInput.SendKeys(password);
            return this;
        }

        public LoginPage ClearPasswordInput()
        {
            PasswordInput.SendKeys(Keys.Control + "a" + Keys.Delete);
            return this;
        }

        public LoginPage SubmitFormExpectingFailure()
        {
            LoginButton.Click();
            return this;
        }

        public MainPage SubmitFormExpectingSuccess()
        {
            LoginButton.Click();
            return new MainPage(driver);
        }

        public string? GetErrorMessageText()
        {
            return ErrorMessage.Text;
        }
    }
}
