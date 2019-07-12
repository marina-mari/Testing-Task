using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using Framework;


namespace Tests
{
    [TestFixture]

    public class UnitTest1
    {
//added some changes
       private DriverManager driverManager;

        [SetUp]
        
        public void Setup()
        {
            driverManager = new ChromeDriverManager();
        }

        [Test]
        public void VerifyRowDeletion()
        {
            HomePage homePage = new HomePage(driverManager.driver);
            LoginPage loginPage =  homePage.clickLoginButton();
            DashboardPage dashboardpage = loginPage.Login("admin@clevergig.nl", "admin");
            GigsPage gigsPage = dashboardpage.ClickGigsTab();
            string firstExpiredRowId = gigsPage.ReturnId();
            DetailsPage detailsPage = gigsPage.ClickEyeButton();
            NUnit.Framework.Assert.IsTrue(detailsPage.IsExpiredPresent());
           GigsPage gigsPage2 = detailsPage.ClickDeleteButton();
           NUnit.Framework.Assert.IsTrue(gigsPage2.IsIdAbsent(firstExpiredRowId));


        }

        [TearDown]
        public void Stop()
        {
           driverManager.CleanDriver();
        }
    }
}
