using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework
{
    public class DashboardPage : BasePage
    {
        public string URL { get { return "http://clevergig.stg.thebrain4web.com/admin"; } }

        [FindsBy(How = How.XPath, Using = @"//*[@class='sidebar-menu']//a [@href = 'http://clevergig.stg.thebrain4web.com/admin/gigs']")]
        private IWebElement gigsTab;


        public DashboardPage(IWebDriver driver) : base(driver)
        {
             PageFactory.InitElements(driver, this);
        }

        public DashboardPage(IWebDriver driver, String url) : base(driver)
        {
            driver.Url = url;
            PageFactory.InitElements(driver, this);
        }

        public GigsPage ClickGigsTab ()
        {
            gigsTab.Click();
            return new GigsPage(driver);
        }


    }
}
