using FinalMarsAutomation.Pages;
using FinalMarsAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace FinalMarsAutomation.StepDefinitions
{
    [Binding]
    public class NegativeFeatureStepDefinitions : CommonDriver

    {
        //initialize login and negativelanguage page objects 
        LogIn logInObject;
        NegativeLanguagePage negativeLanguagePageObject;
        public NegativeFeatureStepDefinitions()
        {
            logInObject = new LogIn();
            negativeLanguagePageObject = new NegativeLanguagePage();

        }
        [Given(@"I have successfully logged into Mars-QA")]
        public void GivenIHaveSuccessfullyLoggedIntoMars_QA()
        {
            logInObject.LogInSteps();
        }

        [When(@"I Add invalid language '([^']*)','([^']*)' into user profile")]
        public void WhenIAddInvalidLanguageIntoUserProfile(string language, string level)
        {
            negativeLanguagePageObject.AddLanguage(language, level);
            
        }

        [Then(@"Invalid language should not be added '([^']*)','([^']*)'")]
        public void ThenInvalidLanguageShouldNotBeAdded(string language, string level)
        {
            //Assertion of added language
            string newLanguage = negativeLanguagePageObject.GetVerifyLanguageAdd();
            string newLevel = negativeLanguagePageObject.GetVerifyLevelAdd();
            if (language == newLanguage && level == newLevel)
            {
                Assert.AreEqual(language, newLanguage, "Actual language and expected language do not match");
                Assert.AreEqual(level, newLevel, "Actual level and expected level do not match");
            }
            else
            {
                Console.WriteLine("Check error");
            }

        }

        [When(@"I Update invalid language '([^']*)','([^']*)' into user profile")]
        public void WhenIUpdateInvalidLanguageIntoUserProfile(string language, string level)
        {
        negativeLanguagePageObject.UpdateLanguage(language, level);
        }

        [Then(@"Invalid language should not be updated '([^']*)','([^']*)'")]
        public void ThenInvalidLanguageShouldNotBeUpdated(string language, string level)
        {
            //Assertion of updated language
            string updatedLanguage = negativeLanguagePageObject.GetVerifyUpdateLanguage();
            string updatedLevel = negativeLanguagePageObject.GetVerifyUpdateLevel();
            if (language == updatedLanguage && level == updatedLevel)
            {
                Assert.AreEqual(language, updatedLanguage, "Actual language and expected language do not match");
                Assert.AreEqual(level, updatedLevel, "Actual level and expected level do not match");
            }
            else
            {
                Console.WriteLine("Check error");
            }

        }
    }
}
