using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework

{
    public class GigsPage : BasePage
    {
        
        public string URL { get { return "http://clevergig.stg.thebrain4web.com/admin/gigs"; } }

        public GigsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public GigsPage(IWebDriver driver, string URL) : base(driver)
        {
            driver.Url = URL;
            PageFactory.InitElements(driver, this);
        }

        private static int SearchFirstExpiredRowCounter (IWebDriver driver)
        {
            var allStatuses = driver.FindElements(By.XPath("//*[@class='label status label-danger']"));
            int counter;
                        

            for (counter = 0; counter < allStatuses.Count; counter ++)
            {
                string actualStatus = allStatuses[counter].GetAttribute("innerText");
                if (actualStatus == "Expired")
                {
                    break;
                }
            }

            return counter;
        }

        public string ReturnId ()
        {
            int counter = SearchFirstExpiredRowCounter(driver);
            IWebElement firstExpiredRowId = driver.FindElements(By.XPath("//*[@class='box-body no-padding']//tr/td[1]"))[counter];
            
            return firstExpiredRowId.GetAttribute("innerText");
        }

        public DetailsPage ClickEyeButton ()
        {
            int counter = SearchFirstExpiredRowCounter(driver);

            IWebElement firstExpiredEyeButton = driver.FindElements(By.XPath("//a[@title='View']"))[counter];
            IJavaScriptExecutor jse = driver as IJavaScriptExecutor;
            jse.ExecuteScript("arguments[0].click()", firstExpiredEyeButton);

            return new DetailsPage(driver);
        }

        public bool IsIdAbsent (string rowid)
        {
            IList <IWebElement> allRows = driver.FindElements(By.XPath("//*[@class='box-body no-padding']//tr/td[1]"));
            foreach (var row in allRows)
            {
               if (row.GetAttribute("innerText") == rowid)
                {
                    return false;
                }

            }
            return true;

        }
   

    }
}