using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FinalMarsAutomation.Pages;

namespace FinalMarsAutomation.Utilities
{
    public class CommonDriver 
    {
        public static IWebDriver driver;

        [OneTimeSetUp ]
        public void Initialize()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
        }


        [OneTimeTearDown]
        public void ClosingSteps()
        {
            driver.Close();
        }
    }
}
