using FinalMarsAutomation.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V113.Browser;
using TechTalk.SpecFlow;

namespace FinalMarsAutomation.Hooks1
{
    [Binding]
    public sealed class Hooks1 : CommonDriver 
    {


        [BeforeScenario]
        public void BeforeScenario()
        {
       Initialize();
        }



        [AfterScenario]
        public void AfterScenario()
        {
                ClosingSteps();
            }
        }
    }
