using FinalMarsAutomation.Pages;
using FinalMarsAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace FinalMarsAutomation.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        // initilize language object
        LogIn logInObject;
        LanguagePage languagePageObject;
        public LanguageFeatureStepDefinitions()
        {
            logInObject = new LogIn();
            languagePageObject = new LanguagePage();
        }
        [Given(@"User has successfully logged in to Mars url")]
        public void GivenUserHasSuccessfullyLoggedInToMarsUrl()
        {
            
            
            
            logInObject.LogInSteps();
        }

        [When(@"I add '([^']*)' , '([^']*)' to my user profile")]
        public void WhenIAddToMyUserProfile(string language, string level)
        {
            
            
            languagePageObject.AddLanguage(language, level);

        }

        [Then(@"Should be able to successfully add '([^']*)' , '([^']*)'to my user profile")]
        public void ThenShouldBeAbleToSuccessfullyAddToMyUserProfile(string language, string level)
        {
            String newLanguage = languagePageObject.GetVerifyLanguageAdd();
            String newLevel=languagePageObject.GetVerifyLevelAdd();
            Assert.AreEqual(language, newLanguage, "Actual language and expected language do not match");
            Assert.AreEqual(level, newLevel, "Actual level and expected level do not match");
        }

        [When(@"I edit exisitng '([^']*)', '([^']*)' listed on  my user profile")]
        public void WhenIEditExisitngListedOnMyUserProfile(string language, string level)
        {
            languagePageObject.UpdateLanguage(language,level);
        }

        [Then(@"Should be able to successfully edit '([^']*)' ,'([^']*)' listed on my user profile")]
        public void ThenShouldBeAbleToSuccessfullyEditListedOnMyUserProfile(string language, string level)
        {
            String updatedLanguage=languagePageObject.GetVerifyLanguageUpdated();
            //trim variable to avoid white space 
            updatedLanguage= updatedLanguage.Trim();
            language=language.Trim();
            string updatedLevelFText = languagePageObject.GetVerifyLevelUpdated();
            updatedLevelFText = updatedLevelFText.Trim();
            level=level.Trim();
            Assert.AreEqual(language, updatedLanguage, "Actual language and updated language do not match");
            Assert.AreEqual(level, updatedLevelFText, "Actual level and updated level do not match");
        }

        [When(@"I delete existing  '([^']*)' , '([^']*)'  on  my user profile")]
        public void WhenIDeleteExistingOnMyUserProfile(string language, string level)
        {
            languagePageObject.DeleteLanguage(language,level);
        }

        [Then(@"Should be able to successfully delete a selected '([^']*)' , '([^']*)'  from my user profile")]
        public void ThenShouldBeAbleToSuccessfullyDeleteASelectedFromMyUserProfile(string language, string level)
        {
            String deletedLanguage=languagePageObject.GetVerifyDeletedLanguage();
            //trim this variable to avoid white space 
            deletedLanguage= deletedLanguage.Trim();
            String deletedLevel=languagePageObject.GetVerifyDeletedLevel();
            //trim this variable to avoid white space 
            deletedLevel = deletedLevel.Trim();
            Assert.AreNotEqual(language, deletedLanguage, "Actual language and expected language do not match");
            Assert.AreNotEqual(level, deletedLevel, "Actual level and expected level do not match");

        }
    }
}
