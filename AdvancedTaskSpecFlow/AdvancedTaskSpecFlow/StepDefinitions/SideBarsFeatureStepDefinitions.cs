using AdvancedTaskSpecFlow.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class SideBarsFeatureStepDefinitions
    {
        private readonly CommonDriver commonDriver;
        public SideBarsFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        [When(@"select '([^']*)'")]
        public void WhenSelect(string Availability)
        {
            commonDriver.sideBars.EditAvailability(Availability);
        }

        [Then(@"The availability should be edited successfully")]
        public void ThenTheAvailabilityShouldBeEditedSuccessfully()
        {
            //Check if the availability has been edited successfully
            string checkPopUpMessage = commonDriver.sideBars.getSideBarMessage();
            Assert.AreEqual(checkPopUpMessage, "Availability updated", "Actual and expected skill record do not match.");
        }

        [When(@"I can select '([^']*)'")]
        public void WhenICanSelect(string Hours)
        {
            commonDriver.sideBars.EditHours(Hours);
        }

        [Then(@"The hours should be edited successfully")]
        public void ThenTheHoursShouldBeEditedSuccessfully()
        {
            //Check if the availability has been edited successfully
            string checkPopUpMessage = commonDriver.sideBars.getSideBarMessage();
            Assert.AreEqual(checkPopUpMessage, "Availability updated", "Actual and expected skill record do not match.");
        }

       

        [When(@"I can edit '([^']*)'")]
        public void WhenICanEdit(string earnTarget)
        {
            commonDriver.sideBars.EditEarnTarget(earnTarget);
        }


        [Then(@"The earn target should be edited successfully")]
        public void ThenTheEarnTargetShouldBeEditedSuccessfully()
        {
            //Check if the availability has been edited successfully
            string checkPopUpMessage = commonDriver.sideBars.getSideBarMessage();
            Assert.AreEqual(checkPopUpMessage, "Availability updated", "Actual and expected skill record do not match.");
        }
    }
}
