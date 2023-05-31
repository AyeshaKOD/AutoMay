using AutoMay.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AutoMay.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions :CommonDrive
    {
        [Given(@"I logged in to Turn Up portal successfully")]
        public void GivenILoggedInToTurnUpPortalSuccessfully()
        {
            throw new PendingStepException();
        }

        [When(@"Navigate to Time & material page")]
        public void WhenNavigateToTimeMaterialPage()
        {
            throw new PendingStepException();
        }

        [When(@"Create a new Time & Material record")]
        public void WhenCreateANewTimeMaterialRecord()
        {
            throw new PendingStepException();
        }

        [Then(@"New time and material record should be created successfully")]
        public void ThenNewTimeAndMaterialRecordShouldBeCreatedSuccessfully()
        {
            throw new PendingStepException();
        }
    }
}
