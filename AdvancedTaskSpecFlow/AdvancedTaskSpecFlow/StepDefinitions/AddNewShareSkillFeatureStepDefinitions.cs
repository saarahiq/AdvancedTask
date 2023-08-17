using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class AddNewShareSkillFeatureStepDefinitions
    {
        [When(@"I click on add button and input valid '([^']*)', '([^']*)'d like to exchange my interview skill traing with other skills\.'([^']*)'Business'([^']*)'Presentations'([^']*)'Selling'([^']*)'Hourly basis service'([^']*)'On-site'([^']*)'(.*)/(.*)'([^']*)''([^']*)'Credit'([^']*)''([^']*)'(.*)'([^']*)'Hidden'")]
        public void WhenIClickOnAddButtonAndInputValidDLikeToExchangeMyInterviewSkillTraingWithOtherSkills_BusinessPresentationsSellingHourlyBasisServiceOn_SiteCreditHidden(string p0, string i, string p2, string p3, string p4, string p5, string p6, string p7, Decimal p8, int p9, string p10, string p11, string p12, string p13, int p14, string p15)
        {
            throw new PendingStepException();
        }

        [Then(@"The new share skill with '([^']*)', '([^']*)'d like to exchange my interview skill traing with other skills\.'([^']*)'Business'([^']*)'Presentations'([^']*)'Selling'([^']*)'Hourly basis service'([^']*)'On-site'([^']*)'(.*)/(.*)'([^']*)''([^']*)'Credit'([^']*)''([^']*)'(.*)'([^']*)'Hidden'should be added successfully")]
        public void ThenTheNewShareSkillWithDLikeToExchangeMyInterviewSkillTraingWithOtherSkills_BusinessPresentationsSellingHourlyBasisServiceOn_SiteCreditHiddenshouldBeAddedSuccessfully(string p0, string i, string p2, string p3, string p4, string p5, string p6, string p7, Decimal p8, int p9, string p10, string p11, string p12, string p13, int p14, string p15)
        {
            throw new PendingStepException();
        }

        [When(@"I click on add button and input valid '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnAddButtonAndInputValid(string p0, string p1, string p2, string p3, string p4, string p5, string p6)
        {
            throw new PendingStepException();
        }

        [Then(@"The new share skill with '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)' should be added successfully")]
        public void ThenTheNewShareSkillWithShouldBeAddedSuccessfully(string p0, string p1, string p2, string p3, string p4, string p5, string p6)
        {
            throw new PendingStepException();
        }

        [When(@"I click on add button and input invalid '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)','([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenIClickOnAddButtonAndInputInvalid(string p0, string programming, string business, string presentations, string selling, string p5, string p6, string p7, string p8, string credit, string p10, string p11, string hidden)
        {
            throw new PendingStepException();
        }

        [Then(@"The new share skill with invalid'([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)', '([^']*)'should be added failed")]
        public void ThenTheNewShareSkillWithInvalidShouldBeAddedFailed(string p0, string programming, string business, string presentations, string selling, string p5, string p6, string p7, string p8, string credit, string p10, string p11, string hidden)
        {
            throw new PendingStepException();
        }
    }
}
