using System;
using System.Configuration;
using NET_Challenge.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Solution_Core;

namespace NET_Challenge
{
   
    [Parallelizable]
    [TestFixture]
    public class AuthenticationTest 
    {
        private WebDriverWait wait;
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            

            driver = BrowserFactory.InitBrowser("Firefox");
            driver.Url = "http://localhost:8080/secure/WelcomeToJIRA.jspa";
              
          
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
        }
       
        [Test]
        public void TestLoginFailed()
        {
            var loginPage = new LoginPage(driver,wait);
            loginPage.FillUser("pepito")
            .FillPassword("")
            .ClickLoguin();
          
            
            string errorMessage = driver.FindElement(By.ClassName("aui-message")).Text;
        
             Assert.AreEqual(errorMessage, "Sorry, your username and password are incorrect - please try again.");

        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
