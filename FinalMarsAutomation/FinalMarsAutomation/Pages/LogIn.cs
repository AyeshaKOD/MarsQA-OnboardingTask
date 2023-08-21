using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalMarsAutomation.Utilities;


namespace FinalMarsAutomation.Pages
{
    public class LogIn : CommonDriver
    {
        //identify elements 
        private static IWebElement skillTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private static IWebElement emailTextBox => driver.FindElement(By.Name("email"));
        private static IWebElement passwordTextBox => driver.FindElement(By.Name("password"));
        private static IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));


        public void LogInSteps()
        {
            //open MRS url
            driver.Navigate().GoToUrl("http://localhost:5000/");
            
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 3);

            try
            {
            
            signInButton.Click();

            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal page didn not load.", ex);
            }


            //Login test 

            
            emailTextBox.SendKeys("nilashinie@gmail.com");
            passwordTextBox.SendKeys("AhasNetha02");
            loginButton.Click();
            Thread.Sleep(4000);
        }
        public void NavigateSkillPage()
        {
            Thread.Sleep(3000);
            skillTab.Click();


        }
    }
}
