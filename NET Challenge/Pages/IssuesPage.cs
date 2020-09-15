using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NET_Challenge.Pages
{
    class IssuesPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IWebElement linkTicket => wait.Until(driver => driver.FindElement(By.ClassName("issue-link-key")));
        private IWebElement todoButton => wait.Until(driver => driver.FindElement(By.Id("action_id_11")));
        private IWebElement progressButton => wait.Until(driver => driver.FindElement(By.Id("action_id_21")));
        private IWebElement doneButton => wait.Until(driver => driver.FindElement(By.Id("action_id_31")));
        
        private IWebElement updateMessage => wait.Until(driver => driver.FindElement(By.Id("aui-flag-container")));


        public IssuesPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;

        }
        public string changeStatus(String status)
        {
            linkTicket.Click();
            Thread.Sleep(3000);
            if (status.Equals("In progress"))
            {
               
                progressButton.Click();
            }
            else if (status.Equals("Done"))
            {
                wait.Until(driver => driver.FindElement(By.Id("action_id_31"))).Click();


            }
            else if (status.Equals("Todo"))
            {
                todoButton.Click();


            }
            return updateMessage.Text;

            
           


        }
    }
}
