using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace NET_Challenge
{
    class BoardPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private MenuComponent menu;
        public BoardPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
            menu = new MenuComponent(driver,wait);

        }
        public void ClickBacklog()
        {
            menu.ClickBacklog();
        }
       
    }
}
