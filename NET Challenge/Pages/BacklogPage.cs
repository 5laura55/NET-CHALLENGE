using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Support;
using System.Threading;

namespace NET_Challenge
{
    class BacklogPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IWebElement newIssue => wait.Until(driver => driver.FindElement(By.XPath("//*[@data-sprint-id='33']//button[contains(text(),'Create issue')]")));
        private IWebElement newIssueTextBox => wait.Until(driver => driver.FindElement(By.XPath("//*[@id='ghx-content-group']//textarea[@name='summary']")));
        private IWebElement issueDetails => wait.Until(driver => driver.FindElement(By.XPath("//*[@id='ghx-content-group']//button[contains(text(),'Open in dialog')]")));
        private IWebElement createIssueButton => wait.Until(driver => driver.FindElement(By.Id("create-issue-submit")));
        
         private IWebElement summaryIssueWindow => wait.Until(driver => driver.FindElement(By.Id("summary")));

        private IWebElement issueDescription => wait.Until(driver => driver.FindElement(By.Id("description"))); 
        private IWebElement issueTypeField => wait.Until(driver => driver.FindElement(By.Id("issuetype-field")));
        private IWebElement issues => wait.Until(driver => driver.FindElement(By.Id("ghx-content-group")));

        private MenuComponent menu;
        public BacklogPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
            menu = new MenuComponent(driver,wait);

        }
        public BacklogPage CreateNewIssue(String issue)
        {
            newIssue.Click();
            

            newIssueTextBox.SendKeys(issue);

            newIssueTextBox.SendKeys(Keys.Enter);
            return this;
        }
        public BacklogPage CreateNewBug(String issue,String steps)
        {
            newIssue.Click();


       

            issueDetails.Click();
            summaryIssueWindow.SendKeys(issue);
            issueTypeField.Click();
            issueTypeField.SendKeys("Bug");
 
            issueDescription.Click();
            issueDescription.SendKeys(steps);
     
            createIssueButton.Click();

        
            return this;
        }
        public bool isTheNewTicket(String issue)
        {

           if( issues.Text.Contains(issue))
            { return true; }
          
            return false;
        }
    }
}
