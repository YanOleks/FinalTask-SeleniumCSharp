using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages.PageObjects
{
    public class BasePage(IWebDriver driver)
    {
        protected readonly IWebDriver driver = driver;
        protected readonly WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

        protected IWebElement WaitForElementToBeClickable(By locator)
        {
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return (element.Displayed && element.Enabled) ? element : null;
            });
        }
    }
}
