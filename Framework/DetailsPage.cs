using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;


namespace Framework
{
    public class DetailsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//*[@class='table']//*[@class='label status label-danger']")]
        private IWebElement status;

       

        public DetailsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public bool IsExpiredPresent ()
        {
            string actualStatus = status.GetAttribute("innerText");
            if (actualStatus == "Expired") return true;
            else return false;
        }

        public GigsPage ClickDeleteButton ()
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("//button[contains (., 'Delete gig')]"));
            deleteButton.Click();
            
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            
            return new GigsPage(driver);
        }
    }
}