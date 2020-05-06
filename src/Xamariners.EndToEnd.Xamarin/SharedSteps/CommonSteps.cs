using System;
using System.IO;
using Shouldly;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.SharedSteps
{
    [Binding]
    public class CommonSteps : StepBase
    {
        // Path to save the screenshots on local run
        protected bool EnableScreenshot { get; set; } = true;
        protected string ScreenshotRoot { get; set; } = @"C:\Screenshots";
        protected string ScreenshotPath { get; private set; }

        public static Guid TestRunId = Guid.NewGuid();

        public CommonSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            ScreenshotPath = $@"{ScreenshotRoot}\{TestRunId}";

            if (!Directory.Exists(ScreenshotPath))
                Directory.CreateDirectory(ScreenshotPath);
        }

        [Given(@"I am on ""([^""]*)"" page")]
        [When(@"I am on ""([^""]*)"" page")]
        [Then(@"I am on ""([^""]*)"" page")]
        public void GivenIAmOnPage(string page)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateWindowMarked(page);
        }

        [Given(@"I can see ""(.*)""")]
        [When(@"I can see ""(.*)""")]
        [Then(@"I can see ""(.*)""")]
        public void GivenICanSee(string marked)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            var results = ScreenQueries.WaitForElementMarked(marked);
            results.ShouldNotBeNull();
            results.Length.ShouldBeGreaterThan(0);

            if(EnableScreenshot)
                ScreenQueries.SaveScreenshot(ScreenshotPath, $"{marked} is visible");
        }

        [Given(@"I tap on ""([^""]*)"" button")]
        [When(@"I tap on ""([^""]*)"" button")]
        [Then(@"I tap on ""([^""]*)"" button")]
        public void WhenITapOn(string marked)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");
           
            ScreenQueries.ValidateButtonMarked(marked);

            ScreenQueries.TapOnButtonMarked(marked);

            if (EnableScreenshot)
                ScreenQueries.SaveScreenshot(ScreenshotPath, $"Tapped on button {marked}");
        }

        [Given(@"The label ""([^""]*)"" text is ""([^""]*)""")]
        [When(@"The label ""([^""]*)"" text is ""([^""]*)""")]
        [Then(@"The label ""([^""]*)"" text is ""([^""]*)""")]
        public void ThenTheLabelTextIs(string marked, string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateLabelMarked(marked);
            ScreenQueries.ValidateLabelText(text);
            ScreenQueries.ValidateLabelText(marked, text);
        }

        [Given(@"I enter ""([^""]*)"" on entry ""([^""]*)""")]
        [When(@"I enter ""([^""]*)"" on entry ""([^""]*)""")]
        [Then(@"I enter ""([^""]*)"" on entry ""([^""]*)""")]
        public void WhenIEnterOnEntry(string text, string marked)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntry(marked);
            ScreenQueries.EnterTextOnElementMarked(marked, text);
        }

        [Given(@"I can see a label marked as ""([^""]*)""")]
        [When(@"I can see a label marked as ""([^""]*)""")]
        [Then(@"I can see a label marked as ""([^""]*)""")]
        public void ThenICanSeeALabelMarkedAs(string marked)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateLabelMarked(marked);
        }

        [Given(@"I can see a label with text ""([^""]*)""")]
        [When(@"I can see a label with text ""([^""]*)""")]
        [Then(@"I can see a label with text ""([^""]*)""")]
        public void ThenICanSeeALabelWithText(string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateLabelText(text);
        }

        [Given(@"The entry ""([^""]*)"" text is ""([^""]*)""")]
        [When(@"The entry ""([^""]*)"" text is ""([^""]*)""")]
        [Then(@"The entry ""([^""]*)"" text is ""([^""]*)""")]
        public void ThenTheEntryTextIs(string marked, string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntryText(marked, text);
        }

        [Given(@"I can see an entry marked as ""([^""]*)""")]
        [When(@"I can see an entry marked as ""([^""]*)""")]
        [Then(@"I can see an entry marked as ""([^""]*)""")]
        public void ThenICanSeeAnEntryMarkedAs(string marked)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntry(marked);
        }

        [Given(@"I can see an entry with text ""([^""]*)""")]
        [When(@"I can see an entry with text ""([^""]*)""")]
        [Then(@"I can see an entry with text ""([^""]*)""")]
        public void ThenICanSeeAnEntryWithText(string text)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateEntryText(text);
        }

        [Given(@"I navigate back")]
        [When(@"I navigate back")]
        [Then(@"I navigate back")]
        public void ThenINavigateBack()
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.NavigateBack();
        }
    }
}