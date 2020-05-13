using Shouldly;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.SharedSteps
{
    [Binding]
    public class NavigationSteps : StepBase
    {

        public NavigationSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"I am on ""([^""]*)"" page")]
        [Then(@"I am on ""([^""]*)"" page")]
        public void GivenIAmOnPage(string page)
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.ValidateWindowMarked(page);

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"I am on page {page}");
        }
        
        [When(@"I navigate back")]
        [Then(@"I navigate back")]
        public void ThenINavigateBack()
        {
            ScreenQueries.ShouldNotBeNull("ScreenQueries != null");

            ScreenQueries.NavigateBack();

            if (RunnerConfiguration.Current.EnableScreenshots)
                ScreenQueries.SaveScreenshot(RunnerConfiguration.Current.ScreenshotsPath, $"I go back");
        }
    }
}