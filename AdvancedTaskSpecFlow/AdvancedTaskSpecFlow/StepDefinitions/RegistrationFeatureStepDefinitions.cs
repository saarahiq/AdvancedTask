using AdvancedTaskSpecFlow.Pages;
using AdvancedTaskSpecFlow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class RegistrationFeatureStepDefinitions
    {

        private readonly CommonDriver commonDriver;
        public RegistrationFeatureStepDefinitions(CommonDriver commonDriver)
        {
            this.commonDriver = commonDriver;
        }

        [When(@"Input valid First name, Last name, Email address, Password, Confirm Password")]
        public void WhenInputValidFirstNameLastNameEmailAddressPasswordConfirmPassword()
        {
            throw new PendingStepException();
        }

        [Then(@"I registered Mars portal successfully")]
        public void ThenIRegisteredMarsPortalSuccessfully()
        {
            throw new PendingStepException();
        }
    }
}
