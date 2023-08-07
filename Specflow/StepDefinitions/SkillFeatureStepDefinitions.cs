using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecflow.StepDefinitions
{
    [Binding]
    public class SkillFeatureStepDefinitions
    {
        [Given(@"I logged in successfully and navigate to Skills Tab to add")]
        public void GivenILoggedInSuccessfullyAndNavigateToSkillsTabToAdd()
        {
            throw new PendingStepException();
        }

        [When(@"I click on Add New button and add Skill details")]
        public void WhenIClickOnAddNewButtonAndAddSkillDetails()
        {
            throw new PendingStepException();
        }

        [Then(@"The new Skill record with '([^']*)' and '([^']*)' should be added successfully and I should see the '([^']*)'")]
        public void ThenTheNewSkillRecordWithAndShouldBeAddedSuccessfullyAndIShouldSeeThe(string specflow, string intermediate, string p2)
        {
            throw new PendingStepException();
        }

        [Given(@"I logged in successfully and navigate to Skills Tab to edit")]
        public void GivenILoggedInSuccessfullyAndNavigateToSkillsTabToEdit()
        {
            throw new PendingStepException();
        }

        [When(@"I edit '([^']*)' and '([^']*)'")]
        public void WhenIEditAnd(string jira, string beginner)
        {
            throw new PendingStepException();
        }

        [Then(@"The new Skill details should be updated with '([^']*)' and '([^']*)' and I should see the '([^']*)'")]
        public void ThenTheNewSkillDetailsShouldBeUpdatedWithAndAndIShouldSeeThe(string jira, string beginner, string p2)
        {
            throw new PendingStepException();
        }

        [Given(@"I logged in successfully and navigate to Skills Tab to delete")]
        public void GivenILoggedInSuccessfullyAndNavigateToSkillsTabToDelete()
        {
            throw new PendingStepException();
        }

        [When(@"I click on the Delete button for '([^']*)' and '([^']*)'")]
        public void WhenIClickOnTheDeleteButtonForAnd(string painting, string intermediate)
        {
            throw new PendingStepException();
        }

        [Then(@"The Skill record should be successfully deleted and I should see the '([^']*)'")]
        public void ThenTheSkillRecordShouldBeSuccessfullyDeletedAndIShouldSeeThe(string p0)
        {
            throw new PendingStepException();
        }
    }
}
