using Shouldly;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.SharedSteps
{
    [Binding]
    public class TouchSteps : StepBase
    {

        public TouchSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
        
        [When(@"I tap on ""([^""]*)"" button")]
        public void WhenITapOn(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");
           
            ScreenQueries.ValidateButtonMarked(mark);

            ScreenQueries.TapOnButtonMarked(mark);

            if(RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Tapped on button {mark}");
        }

        [When(@"I tap on ""([^""]*)"" button at index ""([^""]*)""")]
        public void WhenITapOn(string mark, int index)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateButtonMarked(mark);

            ScreenQueries.TapOnButtonMarked(mark, index);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Tapped on button {mark} at index {index}");
        }

        [When(@"I double tap on ""([^""]*)"" button")]
        public void WhenIDoubleTapOn(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateButtonMarked(mark);

            ScreenQueries.DoubleTapOnButtonMarked(mark);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Double Tapped on button {mark}");
        }

        [When(@"I drag from element ""([^""]*)"" and drop at element ""([^""]*)""")]
        public void WhenIDoubleTapOn(string fromMark, string toMark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.DragAndDropFromElementToElement(fromMark, toMark);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Dragged from {fromMark} to {toMark} ");
        }

        [Then(@"I flash element ""([^""]*)""")]
        [When(@"I flash element ""([^""]*)""")]
        public void WhenIFlashTheElement(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.Flash(mark);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Flashed the webview element {mark}");
        }
    }
}