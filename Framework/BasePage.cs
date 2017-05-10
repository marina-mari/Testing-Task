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
    public class BasePage
    {
        public IWebDriver driver;
        public BasePage(IWebDriver driver) {
            this.driver = driver;
              }
        
    }
}

