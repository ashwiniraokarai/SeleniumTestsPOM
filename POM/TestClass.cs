using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM
{
    public class TestClass
    {
            /*
            Know your test case in terms of “page”
            •	Launch the home page > Click on About link
            •	In the About Page,
                    i.click on the universal search bar collapsed inside the search icon on the top menu
                    ii.submit a search > results page opens
            •	In the Results Page,
                    i.click the click on the first search result link > article page opens
            •	In the Article Page,
                    i.Nothing to do. Simply validate you are in fact on the right page
            */

        //Instantiate the webdriver. Remember Page Objects should depend on the Test Class to instantiate the driver. 
        //Test Class controls the driver and passes it back and forth between itself and the page objects to get its job done

        //SetUp
        IWebDriver driver;
        readonly String searchText = "selenium c#";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        
        [Test]
        public void Test()
        {
          HomePage homePage = new HomePage(driver);
            homePage.Navigate();
            AboutPage aboutPage = homePage.GoToAboutPage();
            ResultPage resultPage = aboutPage.SubmitSearch(searchText);
            resultPage.ClickOnFirstResult(searchText);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
