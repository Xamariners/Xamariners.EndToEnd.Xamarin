using TechTalk.SpecFlow;

namespace Xamariners.EndToEnd.Xamarin.Infrastructure
{
    [Binding]
    public class SetupHooksBase
    {
        protected readonly ScenarioContext _scenarioContext;

        public SetupHooksBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
        }

        [BeforeFeature("disableCache")]
        public static void BeforeFeatureDisableBache()
        {
        }

        [BeforeFeature("clearCache")]
        public static void BeforeFeatureEnableCache()
        {
        }
    }
}
