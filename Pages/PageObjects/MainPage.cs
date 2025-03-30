using OpenQA.Selenium;

namespace Pages.PageObjects
{
    public class MainPage(IWebDriver driver) : BasePage(driver)
    {
        private Lazy<IWebElement> DashboardTitle => new(() => WaitForElementToBeVisible(By.ClassName("app_logo")));

        public string GetDashboardTitleText()
        {
            return DashboardTitle.Value.Text;
        }
    }
}
