using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingNUnit
{
    class NUnitTestWithAnnotations
    {
        //This program only works on Chrome. Couldnt run in the IE bcoz of driver object
        IWebDriver driver= new ChromeDriver();
        string s;


        //This main code is mandotary for console application if you run as NUnit tests
        [STAThread]
        static void Main()
        {
        }

        //Install Nunit3 framework, testAdapter,console runner and initialize the Startup Object
        [SetUp]
        public void InitBrowserIE()
        {
            driver.Navigate().GoToUrl("http://www.seleniumhq.org/download/");
            Console.WriteLine("Opened the app successfully");
         
        }
        
       [Test]
        public void testingSeleniumApp()
        {

            try
            {
                s = driver.Title;
                IWebElement searchEle = driver.FindElement(By.XPath("//input[@id='q']"));
                Console.WriteLine("The element is found");
               
                validatingTheSeleniumApp(searchEle);

            }
            catch (NoSuchElementException)
            {

                Console.WriteLine("The Element is not found");
            }
            
       }
       
        public void validatingTheSeleniumApp(IWebElement textTiEnter)
        {
            
            if (textTiEnter.Displayed)
                textTiEnter.SendKeys("surya");
            driver.FindElement(By.Id("submit")).Click();
            Console.WriteLine("Verified the page"+ driver.Title);
            Screenshot s = ((ITakesScreenshot)driver).GetScreenshot();
            s.SaveAsFile("C:\\Users\\admin\\Documents\\Visual Studio 2015\\Projects\\TestingNUnit\\Image.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.Read();

            
        }


        [TearDown]
        public void ClosingTheBrowser()
        {
            driver.Close();
        }

    }
}
