using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.PageObjects
{
    class AboutPage
    {
        readonly IWebDriver driver;
        WebDriverWait wait;
        public AboutPage(IWebDriver driver)  //Instantiated by HomePage
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //no explicit "navigation" to About page needed. It was already done when "About" was clicked on using the HomePage object

        //Locators
        [FindsBy(How = How.CssSelector, Using = "ul[id = 'menu-main'] a[class = 'fusion-main-menu-icon fusion-bar-highlight']")]
        private readonly IWebElement searchIcon;

        [FindsBy(How = How.CssSelector, Using = "ul[id = 'menu-main'] li[class *= 'fusion-main-menu-search-open'] div[class = 'fusion-custom-menu-item-contents'] input[class = 's']")]
        readonly IWebElement searchInputBox;

        //Actions that operate on the locators

        //Goal: Submit the search text leading to the results page
        public ResultPage SubmitSearch(string searchText)
        {
            Assert.That(driver.Title, Is.EqualTo("About"));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchIcon)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(searchInputBox)).SendKeys(searchText);
            searchInputBox.Submit();
            return new ResultPage(driver);
        }
    }
}
