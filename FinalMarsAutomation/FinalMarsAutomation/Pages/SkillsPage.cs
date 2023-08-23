using FinalMarsAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalMarsAutomation.Pages
{
    //inherit commondriver class 
    public class SkillsPage: CommonDriver
    {
       //identify elements 
        private static IWebElement addNewSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement skillText => driver.FindElement(By.Name("name"));
        private static IWebElement levelText => driver.FindElement(By.Name("level"));
        private static IWebElement addSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        private static IWebElement addedSkillText => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private static IWebElement addedLevelText => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        
        private static IWebElement updateSkillIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement updateLevelDropdown => driver.FindElement(By.Name("level"));
        private static IWebElement updateSkillText => driver.FindElement(By.Name("name"));
        
        private static IWebElement finalUpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement updatedNewSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement updatedNewLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement deletedSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement deletedSkillLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
        public void AddSkills(String skill, String sLevel)
        {
            //go to skills section and add new skills
            //skillTab.Click();

            Thread.Sleep(2000);
            addNewSkillButton.Click();                                      
            skillText.SendKeys(skill);
            levelText.SendKeys(sLevel); 
            addSkillButton.Click();                                     


        }
        public String  GetVerifySkill()
        {
            Thread.Sleep(3000);
            return addedSkillText.Text;                                 

        }
        public String GetVerifySkillLevel()
        {
            Thread.Sleep(3000);
            return addedLevelText.Text;

        }
        public void UpdateSkills(String skill, String sLevel)
        {
            //click edit icon and update existing skills
            Thread.Sleep(2000);
            updateSkillIcon.Click();                                    

            
            updateSkillText.Clear();
            updateSkillText.SendKeys(skill);

            //select level from the drop down 
            SelectElement element = new SelectElement(updateLevelDropdown);
            element.SelectByText(sLevel);

            
            finalUpdateButton.Click();                                  
        }
        public String GetVerifyUpdatedSkill()
        {
            //retrieve  updated language 
            Thread.Sleep(4000);
            return updatedNewSkill.Text;                                
        }
        public String GetVerifyUpdatedLevel()
        {
            //retrieve  updated level
            Thread.Sleep(4000);
            return updatedNewLevel.Text;                                
        }
        public void DeleteSkill(String skill, String sLevel)
        {
            Thread.Sleep(2000);
            //Find all the rows in skills table 
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));
            Thread.Sleep(2000);                                                                                                       
            foreach (IWebElement row in rows)
            {
                // Get the text of the first column (skill column) in the row
                IWebElement skillElement = row.FindElement(By.XPath("./td[1]"));
                
                IWebElement skillLevel = row.FindElement(By.XPath("./td[2]"));
                
                string skillText = skillElement.Text;
                string skillLevelText = skillLevel.Text;
                Thread.Sleep(2000);
                // Check if the language matches the provided text
                if (skillText.Equals(skill, StringComparison.OrdinalIgnoreCase) && skillLevelText.Equals(sLevel, StringComparison.OrdinalIgnoreCase))
                {
                    // Find and click the delete icon in the row
                    IWebElement deleteIcon = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                    deleteIcon.Click();                                 
                    Thread.Sleep(2000);
                    break;
                }

            }
            
        }
        public String GetDeletedSkill(String skill, String sLevel)
        {
            //retrieve deleted skill
            Thread.Sleep(2000);
            return deletedSkill.Text;                               
        }
        public String GetDeletedSkillLevel(String skill, String sLevel)
        {
            //retrieve deleted skill level 
            Thread.Sleep(2000);
            return deletedSkillLevel.Text;
        }

        }
}

