using Shouldly;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.SharedSteps
{
    [Binding]
    public class WebViewSteps : StepBase
    {
        public WebViewSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When(@"I flash webview element ""([^""]*)""")]
        [Then(@"I flash webview element ""([^""]*)""")]
        public void WhenIFlashTheWebviewElement(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");
           
            ScreenQueries.WebViewFlashElement(mark);

            if(RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Flashed the webview element {mark}");
        }

        [When(@"I scroll webview to coordinates x ""([^""]*)"" and y ""([^""]*)""")]
        public void WhenIScrollWebViewToCoordinates(float x, float y)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.WaitWebView();
            ScreenQueries.ManualWebViewScroll(x,y);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Scrolled the webview to coordinates x {x} and y {y}");
        }

        [When(@"I scroll down webview to element ""([^""]*)""")]
        public void WhenIScrollDownWebViewToElement(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.WaitWebView();
            ScreenQueries.ScrollWebViewDown(mark);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Scrolled down the webview to element {mark}");
        }

        [When(@"I scroll up webview to element ""([^""]*)""")]
        public void WhenIScrollUpWebViewToElement(string mark)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.WaitWebView();
            ScreenQueries.ScrollWebViewUp(mark);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"Scrolled up the webview to element {mark}");
        }
    }
}