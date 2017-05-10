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
    public class LoginPage : BasePage
    {

        public string URL { get { return "http://clevergig.stg.thebrain4web.com/en/auth/login"; } }

        [FindsBy(How = How.XPath, Using = @"//input [@name = 'email'] [@placeholder = 'Email address']")]
        private IWebElement emailTestbox;

        [FindsBy(How = How.XPath, Using = @"//input [@name = 'password'] [@placeholder = 'Password']")]
        private IWebElement passwordTestbox;

        [FindsBy(How = How.XPath, Using = @"//input [@type='submit']")]
        private IWebElement submitButton;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public LoginPage(IWebDriver driver, String url) : base(driver)
        {
            driver.Url = url;
            PageFactory.InitElements(driver, this);
        }
         
        public DashboardPage Login(string login, string pass)
        {
            
            emailTestbox.SendKeys(login);
            passwordTestbox.SendKeys(pass);
            submitButton.Click();

            return new DashboardPage(driver);
        }

    }
}
