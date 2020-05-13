using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Screens.Interface;

namespace Xamariners.EndToEnd.Xamarin.Infrastructure
{
    public abstract class StepBase
    {
        protected readonly ScenarioContext _scenarioContext;
        
        protected IScreenQueries ScreenQueries => RunnerConfiguration.Current.ScreenQueries;

        protected StepBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}