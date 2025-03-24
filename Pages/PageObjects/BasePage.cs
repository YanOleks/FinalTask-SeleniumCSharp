using OpenQA.Selenium;

namespace Pages.PageObjects
{
    public class BasePage
    {
        private static readonly int TIMEOUT = 3;
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIMEOUT);
        }
    }
}
