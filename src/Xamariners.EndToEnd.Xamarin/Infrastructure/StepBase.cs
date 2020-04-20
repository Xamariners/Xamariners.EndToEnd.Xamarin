using TechTalk.SpecFlow;
using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Features;
using Xamariners.EndToEnd.Xamarin.Screens.Interface;

namespace Xamariners.EndToEnd.Xamarin.Infrastructure
{
    public abstract class StepBase
    {
        protected readonly ScenarioContext _scenarioContext;

        protected IApp App => BaseFeature.App;
        protected IScreenQueries ScreenQueries => BaseFeature.ScreenQueries;

        protected StepBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}