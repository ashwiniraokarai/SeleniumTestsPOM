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
    class ResultPage
    {
        IWebDriver driver;
        String getfirstResultText;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Locators
        [FindsBy(How = How.CssSelector, Using = "div[id = 'posts-container'] div article:nth-child(1) h2[class = 'entry-title fusion-post-title'] a")]
        IWebElement firstSearchResult;


        //no explicit "navigation" to Results page needed. It was already done when search was submitted using the AboutPage object

        //Goal: Click on the first result on this page
        public ArticlePage ClickOnFirstResult(String searchText)
        {
            Assert.IsTrue(driver.Title.Equals("You searched for " + searchText + " - Software Test Academy"));
            getfirstResultText = firstSearchResult.Text; //"Selenium C# and NUnit Pain Free Start Guide"
            firstSearchResult.Click();
            return new ArticlePage(driver, getfirstResultText); //Pass the result text so you can verify the page title of ArticlePage against it
        }



    }
}
