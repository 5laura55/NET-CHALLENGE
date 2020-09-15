using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace NET_Challenge.Utils
{
    class BrowserFactory
    {
        private  static IWebDriver driver;
        public  static IWebDriver InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":

                    driver = new FirefoxDriver();                  
                    break;

                case "IE":                 
                        driver = new InternetExplorerDriver();
             break;

                case "Chrome":
                   
                        driver = new ChromeDriver();       
                    break;
            }
            return driver;
        }

    }
}
