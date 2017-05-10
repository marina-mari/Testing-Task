using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework
{
    public class HomePage : BasePage
    {
        public const string URL = "http://clevergig.stg.thebrain4web.com";

        [FindsBy(How = How.XPath, Using = @"//div [@class = 'topSection']//a [@href='http://clevergig.stg.thebrain4web.com/en/auth/login']")]
        private IWebElement loginButton;

        public HomePage(IWebDriver driver): base (driver)
        {
            driver.Url = URL;
            PageFactory.InitElements(driver, this);
        }

        public LoginPage clickLoginButton ()
        {
           loginButton.Click();

            return new LoginPage(driver);
        }
    }
}
