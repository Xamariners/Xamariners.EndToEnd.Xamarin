using Shouldly;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.SharedSteps
{
    [Binding]
    public class EntrySteps : StepBase
    {

        public EntrySteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
        
        [When(@"I enter ""([^""]*)"" on entry ""([^""]*)""")]
        public void WhenIEnterOnEntry(string text, string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntry(mark);

            ScreenQueries.EnterTextOnElementMarked(mark, text);

            ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"I enter '{text}' on entry {mark}");

        }

        [When(@"I dont clear and enter ""([^""]*)"" on entry ""([^""]*)""")]
        public void WhenIDontClearClearAndEnterOnEntry(string text, string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntry(mark);
            
            ScreenQueries.EnterTextOnElementMarked(mark, text, false);

            ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"I enter '{text}' on entry {mark}");
        }
        
        [When(@"I can see the entry ""([^""]*)"" text is ""([^""]*)""")]
        [Then(@"I can see the entry""([^""]*)"" text is ""([^""]*)""")]
        public void ThenTheEntryTextIs(string mark, string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntryText(mark, text);
        }

        [Given(@"I can see entry marked ""([^""]*)""")]
        [Then(@"I can see an entry marked ""([^""]*)""")]
        public void ThenICanSeeAnEntryMarkedAs(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntry(mark);
        }

        [Given(@"I can see entry with text ""([^""]*)""")]
        [Then(@"I can see entry with text ""([^""]*)""")]
        public void ThenICanSeeAnEntryWithText(string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntryText(text);
        } 
    }
}