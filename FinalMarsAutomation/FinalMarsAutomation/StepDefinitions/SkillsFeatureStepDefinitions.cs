using FinalMarsAutomation.Pages;
using FinalMarsAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace FinalMarsAutomation.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions : CommonDriver
    {
        //initialize skills and login object
        LogIn logInObject;
        SkillsPage skillsPageObject;
        public SkillsFeatureStepDefinitions()
        {
            logInObject = new LogIn();
            skillsPageObject = new SkillsPage();
        }

        [Given(@"I have successfully logged in to Mars url")]
        public void GivenIHaveSuccessfullyLoggedInToMarsUrl()
        {
            logInObject.LogInSteps();
        }

        [Given(@"I have navigated to Skills page")]
        public void GivenIHaveNavigatedToSkillsPage()
        {
            logInObject.NavigateSkillPage();
        }

        [When(@"I  add '([^']*)', '([^']*)' to my Skills section on my profile page")]
        public void WhenIAddToMySkillsSectionOnMyProfilePage(string skill, string sLevel)
        {
            skillsPageObject.AddSkills(skill, sLevel);
        }

        [Then(@"Should be able to successfully add '([^']*)', '([^']*)' to Skills section on my profile page")]
        public void ThenShouldBeAbleToSuccessfullyAddToSkillsSectionOnMyProfilePage(string skill, string sLevel)
        {
            String newSkill = skillsPageObject.GetVerifySkill();
            newSkill=newSkill.Trim();
            skill=skill.Trim();
            String newSkillLevel = skillsPageObject.GetVerifySkillLevel();
            newSkillLevel=newSkillLevel.Trim();
            sLevel=sLevel.Trim();
            Assert.AreEqual(skill, newSkill, "Actual skill and expected skill do not match");
            Assert.AreEqual(sLevel, newSkillLevel, "Actual level and expected level do not match");
        }

        [When(@"I update exisitng '([^']*)', '([^']*)' on  Skills section on my profile page")]
        public void WhenIUpdateExisitngOnSkillsSectionOnMyProfilePage(string skill, string sLevel)
        {
            skillsPageObject.UpdateSkills(skill, sLevel);
        }

        [Then(@"Should be able to successfully update existing '([^']*)', '([^']*)' to Skills section")]
        public void ThenShouldBeAbleToSuccessfullyUpdateExistingToSkillsSection(string skill, string sLevel)
        {
            String updatedSkill = skillsPageObject.GetVerifyUpdatedSkill();
            updatedSkill= updatedSkill.Trim();
            skill = skill.Trim();
            String updatedSkillLevel = skillsPageObject.GetVerifySkillLevel();
            updatedSkillLevel= updatedSkillLevel.Trim();
            //sLevel=sLevel.Trim();
            Assert.AreEqual(skill, updatedSkill, "Actual skill and updated skill do not match");
            Assert.AreEqual(sLevel, updatedSkillLevel, "Actual skill level and updated skill level do not match");
        }

        [When(@"I delete existing '([^']*)', '([^']*)' on my Skills section")]
        public void WhenIDeleteExistingOnMySkillsSection(string skill, string sLevel)
        {
            skillsPageObject.DeleteSkill(skill, sLevel);
        }

        [Then(@"Should be able to successfully delete existing '([^']*)', '([^']*)' on Skills section of my profile page")]
        public void ThenShouldBeAbleToSuccessfullyDeleteExistingOnSkillsSectionOfMyProfilePage(string skill, string sLevel)
        {
            string deletedSkillText = skillsPageObject.GetDeletedSkill(skill, sLevel);
            deletedSkillText= deletedSkillText.Trim();
            skill=skill.Trim();

            string deletedSkillLevelText = skillsPageObject.GetDeletedSkillLevel(skill, sLevel);
            deletedSkillLevelText= deletedSkillLevelText.Trim();
            sLevel=sLevel.Trim();
            Assert.AreNotEqual(skill, deletedSkillText, "Actual skill and expected skill do not match");
            Assert.AreNotEqual(sLevel, deletedSkillLevelText, "Actual level and expected level do not match");
        }
    }
}

