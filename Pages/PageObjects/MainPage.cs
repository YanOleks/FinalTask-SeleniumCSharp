using OpenQA.Selenium;

namespace Pages.PageObjects
{
    public class MainPage(IWebDriver driver) : BasePage(driver)
    {
        private IWebElement DashboardTitle => driver.FindElement(By.ClassName("app_logo"));

        public string GetDashboardTitleText()
        {
            return DashboardTitle.Text;
        }
    }
}
