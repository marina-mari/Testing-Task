using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;

namespace Framework
{
    public abstract class DriverManager
    {
        public IWebDriver driver;

        public DriverManager (IWebDriver driverM)
        {
            this.driver = driverM;
        }

        public abstract void CleanDriver();
        
        
    }

    public class ChromeDriverManager : DriverManager
    {
        //private const string PATH = "C:\\Users\\miroslava\\Downloads\\chromedriver_win32";
        private static string PATH = System.Environment.GetEnvironmentVariable("driverPath");
        private const int seconds = 5;

        public ChromeDriverManager() : base(new ChromeDriver(PATH)) {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public override void CleanDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
