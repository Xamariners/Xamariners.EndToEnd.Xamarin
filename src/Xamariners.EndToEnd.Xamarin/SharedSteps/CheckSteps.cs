using Shouldly;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.SharedSteps
{
    [Binding]
    public class CheckSteps : StepBase
    {
        public CheckSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"I can see ""(.*)""")]
        [When(@"I can see ""(.*)""")]
        [Then(@"I can see ""(.*)""")]
        public void GivenICanSee(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            var results = ScreenQueries.WaitForElementMarked(mark);
            results.ShouldNotBeNull();
            results.Length.ShouldBeGreaterThan(0);

            if(RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"{mark} is visible");
        }

        [Given(@"I can see label ""([^""]*)"" text ""([^""]*)""")]
        [When(@"I can see label ""([^""]*)"" text ""([^""]*)""")]
        [Then(@"I can see label ""([^""]*)"" text ""([^""]*)""")]
        public void ThenTheLabelTextIs(string mark, string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateLabelMarked(mark);
            ScreenQueries.ValidateLabelText(text);
            ScreenQueries.ValidateLabelText(mark, text);
        }

        [Given(@"I can see a label marked as ""([^""]*)""")]
        [When(@"I can see a label marked as ""([^""]*)""")]
        [Then(@"I can see a label marked as ""([^""]*)""")]
        public void ThenICanSeeALabelMarkedAs(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateLabelMarked(mark);
        }

        [Given(@"I can see label with text ""([^""]*)""")]
        [When(@"I can see label with text ""([^""]*)""")]
        [Then(@"I can see label with text ""([^""]*)""")]
        public void ThenICanSeeALabelWithText(string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateLabelText(text);
        }

        [Given(@"I can see a label containing text ""([^""]*)""")]
        [When(@"I can see a label containing text ""([^""]*)""")]
        [Then(@"I can see a label containing text ""([^""]*)""")]
        public void ThenICanSeeALabelContainingText(string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateMessageContainingText(text);
        }

        [Given(@"I can see element ""([^""]*)"" disappears")]
        [When(@"I can see element ""([^""]*)"" disappears")]
        [Then(@"I can see element ""([^""]*)"" disappears")]
        public void ThenITheElementDisappears(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.WaitForNoElementMarked(mark);
        }

        [Given(@"I wait for element ""([^""]*)""")]
        [When(@"I wait for element ""([^""]*)""")]
        [Then(@"I wait for element ""([^""]*)""")]
        public void WhenIWaitForTheElement(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");
            ScreenQueries.WaitForElementMarked(mark);
        }
    }
}