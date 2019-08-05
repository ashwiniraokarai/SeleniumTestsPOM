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
        //What is your goal?
        //Go to home page https://www.swtestacademy.com, click on "About" which in turn opens the About Page
        //Go to About Page
        //Click on Search magnifying glass icon (opens the search bar)
        //Enter text in the Search input box. Pass the search string from here as an argument.
        //Click the Search button (submits the search and open the Results page)
        //In the Results page, click on the first result

        //Instantiate the webdriver. Remember Page Objects should depend on the Test Class to instantiate the driver. 
        //Test Class controls the driver and passes it back and forth between itself and the page objects to get its job done
        
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void Test()
        {
          HomePage homePage = new HomePage(driver);
        }
        
    }
}
