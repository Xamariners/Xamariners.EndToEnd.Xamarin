using Shouldly;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.SharedSteps
{
    [Binding]
    public class ScrollSteps : StepBase
    {

        public ScrollSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When(@"I scroll down to element ""([^""]*)""")]
        public void WhenIScrollDownTo(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");
           
            ScreenQueries.ScrollDownToMarked(mark);

            if(RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Scrolled down to element {mark}");
        }

        [When(@"I scroll up to element ""([^""]*)""")]
        public void WhenIScrollUpTo(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ScrollUpToMarked(mark);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Scrolled up to element {mark}");
        }

        [When(@"I scroll to element ""([^""]*)""")]
        public void WhenIScrollTo(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ScrollToMarked(mark);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Scrolled to element {mark}");
        }
    }
}