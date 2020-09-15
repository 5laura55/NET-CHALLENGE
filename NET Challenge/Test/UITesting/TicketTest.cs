using System;
using System.Configuration;
using System.Threading;
using NET_Challenge.Pages;
using NET_Challenge.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Solution_Core;

namespace NET_Challenge
{
   
    [Parallelizable]
    [TestFixture]
    public class TicketTest 
    {
        private WebDriverWait wait;
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            

            driver = BrowserFactory.InitBrowser("Chrome");
            driver.Url = "http://localhost:8080/secure/WelcomeToJIRA.jspa";
              
          
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
        }
       
    
       
        [Test]
        public void TestCreateStory()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.FillUser(ConfigurationManager.AppSettings["Username"])
          .FillPassword(ConfigurationManager.AppSettings["Password"])
          .ClickLoguin();
            DashboardPage mainPage = new DashboardPage(driver, wait);
            mainPage.selectCurrentProject();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            BoardPage board = new BoardPage(driver, wait);
            board.ClickBacklog();
            BacklogPage backlog = new BacklogPage(driver, wait);
            backlog.CreateNewIssue("this is a new issue");
            Assert.IsTrue(backlog.isTheNewTicket("this is a new issue"));

        }
        [Test]
        public void TestCreateBug()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.FillUser(ConfigurationManager.AppSettings["Username"])
               .FillPassword(ConfigurationManager.AppSettings["Password"])
               .ClickLoguin();
            DashboardPage mainPage = new DashboardPage(driver, wait);
            mainPage.selectCurrentProject();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            BoardPage board = new BoardPage(driver, wait);
            board.ClickBacklog();
            BacklogPage backlog = new BacklogPage(driver, wait);
            backlog.CreateNewBug("this is a new bug", "step 1, step2");
            Assert.IsTrue(backlog.isTheNewTicket("this is a new bug"));

        }
        [Test]
        public void changeStatus()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.FillUser(ConfigurationManager.AppSettings["Username"])
               .FillPassword(ConfigurationManager.AppSettings["Password"])
               .ClickLoguin();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

            driver.Url = "http://localhost:8080/projects/CHALL/issues/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6000);
            IssuesPage issuesPage = new IssuesPage(driver, wait);
         var message= issuesPage.changeStatus("Done");
            Assert.That(message , Contains.Substring("has been updated"));

            Thread.Sleep(3000);
            

        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
