using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class RegistrationFeatureStepDefinitions
    {
        [Given(@"Launch Mars portal")]
        public void GivenLaunchMarsPortal()
        {
            
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
