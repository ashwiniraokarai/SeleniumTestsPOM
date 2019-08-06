using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.PageObjects
{
    class ArticlePage
    {
        IWebDriver driver;
        String getfirstResultText;

        public ArticlePage(IWebDriver driver, String getfirstResultText)
        {
            this.driver = driver;
            this.getfirstResultText = getfirstResultText;
            PageFactory.InitElements(driver, this);
        }

        public void VerifyPage()
        {
            Assert.That(driver.Title, Is.EqualTo("getfirstResultText"));
        }

    }
}
