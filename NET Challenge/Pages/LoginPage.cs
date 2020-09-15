using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Solution_Core
{
    class LoginPage
    {
       private IWebDriver driver;
        private WebDriverWait wait;
        private IWebElement userField => wait.Until(driver => driver.FindElement(By.Id("login-form-username")));
        private IWebElement passwordField => wait.Until(driver => driver.FindElement(By.Id("login-form-password")));
        private IWebElement loguinButton => wait.Until(driver => driver.FindElement(By.Id("login-form-submit")));
        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;

        }
        public LoginPage FillUser(string user)
        {
            userField.SendKeys(user);
            return this;
        }
        public LoginPage FillPassword(string pass)
        {
            passwordField.SendKeys(pass);
            return this;
        }
        public LoginPage ClickLoguin()
        {
            loguinButton.Click();
            return this;
        }
    }
}
