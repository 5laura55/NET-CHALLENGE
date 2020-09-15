using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NET_Challenge
{
    class MenuComponent
    {
        private IWebDriver driver; 
        private WebDriverWait wait;
        private IWebElement backlogTab => wait.Until(driver => driver.FindElement(By.XPath("//*[@id='content']//a[@href='/secure/RapidBoard.jspa?projectKey=CHALL&rapidView=33&view=planning']")));

        public MenuComponent(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;

        }
        public MenuComponent ClickBacklog()
        {
            backlogTab.Click();
            return this;
        }
      
    }
}
