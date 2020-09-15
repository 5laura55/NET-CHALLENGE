using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Solution_Core
{
    public class DashboardPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IWebElement selectorProject => wait.Until(driver => driver.FindElement(By.Id("browse_link")));
        private IWebElement projectOption => wait.Until(driver => driver.FindElement(By.Id("admin_main_proj_link_lnk")));

        public DashboardPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;

        }
        public DashboardPage selectCurrentProject()
        {
            selectorProject.Click();
            projectOption.Click();
            return this;
            
        }
    }
}
