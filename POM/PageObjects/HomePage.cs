using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.PageObjects
{
    class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver) //Instantiated by TestClass
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this); //Initializes elements in the HomePage bject (elements that are going to be written)
        }

        //Launch the Home page
        public void Navigate()
        {
            driver.Navigate().GoToUrl("https://www.swtestacademy.com/");
            Assert.That(driver.Title, Is.EqualTo("Software Test Academy"));
        }

        [FindsBy(How = How.CssSelector, Using = "ul[id = 'menu-main'] a[href *= 'about']")]
        private readonly IWebElement aboutInMainMenu;

        //Go to About page
        public AboutPage GoToAboutPage()
        {
            aboutInMainMenu.Click(); //Click "about" in main menu
            return new AboutPage(driver); //Return the About Page
        }

    }
}
