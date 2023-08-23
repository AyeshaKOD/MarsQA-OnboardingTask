using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;
using FinalMarsAutomation.Utilities;
using OpenQA.Selenium.Support.UI;
//using static System.Collections.Specialized.BitVector32;

namespace FinalMarsAutomation.Pages
{
    public class LanguagePage : CommonDriver
    {
        
        //identify elements 
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement enterLanguageText => driver.FindElement(By.Name("name"));
        private static IWebElement selectLevel => driver.FindElement(By.Name("level"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement newLanguageAdded => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement levelAdded => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement editIcon => driver.FindElement(By.XPath("//td[@class='right aligned']//i[@class='outline write icon']"));
        private static IWebElement getLanguageText => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private static IWebElement getLevelTextDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
                                                                                        
        private static IWebElement finalUpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement updatedLanguageText => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement updatedLevelTextDdown => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody/tr[1]/td[2]"));
                                                                                
        private static IWebElement deletedLanguageText => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement deletedLevelText => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
        public void AddLanguage(String language, String level)
        {

            //click add new button
            addNewButton.Click();

            // enter a language and level
            enterLanguageText.SendKeys(language);
            selectLevel.SendKeys(level);
            addButton.Click();
           
        }
        public String GetVerifyLanguageAdd()
        {
            Thread.Sleep(2000);
            return newLanguageAdded.Text;
        }
        public String GetVerifyLevelAdd()
        {
            Thread.Sleep(2000);
            return levelAdded.Text;
        }

        public void UpdateLanguage( String language, String level)
        {
            //click edit icon and edit language details 
            Thread.Sleep(2000);
            editIcon.Click();                                   
            Thread.Sleep(2000);

            
            getLanguageText.Clear();                                    
            getLanguageText.SendKeys(language);
            Thread.Sleep(4000);

           // select the elemnt from drop down 
            SelectElement element = new SelectElement(getLevelTextDropdown);
            element.SelectByText(level);
            Thread.Sleep(2000);

            
            finalUpdateButton.Click();                                  
            Thread.Sleep(3000);
        }
        public String GetVerifyLanguageUpdated()
        {
            //retrieve updated language 
            Thread.Sleep(2000);
            return updatedLanguageText.Text;                                
        }
        public string GetVerifyLevelUpdated()
        {
            //retrieve updated level
            Thread.Sleep(2000);
            
            //return it as a text
            return updatedLevelTextDdown.Text;
        }
        public void DeleteLanguage( String language, String level)
        {
            Thread.Sleep(2000);
            // Find all rows in the table
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
            Thread.Sleep(2000);

            foreach (IWebElement row in rows)
            {
                // Get the text of the first column (language column) in the row
                IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                IWebElement languageLevel = row.FindElement(By.XPath("./td[2]"));
                string languageText = languageElement.Text;
                string languageLevelText = languageLevel.Text;
                Thread.Sleep(2000);

                // Check if the language matches the provided text
                if (languageText.Equals(language, StringComparison.OrdinalIgnoreCase) && languageLevelText.Equals(level, StringComparison.OrdinalIgnoreCase))
                {
                    // Find and click the delete icon in the row
                    IWebElement deleteIcon = row.FindElement(By.XPath("./td[3]/span[2]/i"));
                    // Thread.Sleep(2000);
                    deleteIcon.Click();
                    Thread.Sleep(2000);
                    break;
                }

            }
        }
        public String GetVerifyDeletedLanguage()
        {
            //retrieve deleted language 
            Thread.Sleep(2000);
            return deletedLanguageText.Text;                                
        }
        public String GetVerifyDeletedLevel()
        {
            //retrieve deleted level 
            Thread.Sleep(2000);
            return deletedLevelText.Text;                               
        }
    }
}
    
