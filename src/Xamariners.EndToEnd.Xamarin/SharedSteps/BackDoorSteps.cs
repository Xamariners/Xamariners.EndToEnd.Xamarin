using System.Runtime.InteropServices.ComTypes;
using Shouldly;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.SharedSteps
{
    [Binding]
    public class BackDoorSteps : StepBase
    {
        public BackDoorSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When(@"I invoke the backdoor method ""(.*)"" with param ""(.*)""")]
        public object WhenIInvokeTheBackdoorMethodWithParam(string method, string param)
        {
            if (RunnerConfiguration.Platform == Platform.iOS && !method.Contains(":"))
                method += ":";

            var result = RunnerConfiguration.Current.App.Invoke(method, param);
            
            _scenarioContext.Add("backdoor_result", result);

            return result;
        }

        [When(@"I invoke the backdoor method ""(.*)"" without param")]
        public object WhenIInvokeTheBackdoorMethod(string method)
        {
            var result = RunnerConfiguration.Current.App.Invoke(method);

            _scenarioContext.Add("backdoor_result", result);

            return result;
        }

        [Then(@"the backdoor string result is ""(.*)""")]
        public void ThenITheBackdoorResultIs(string text)
        {
            var result = _scenarioContext.Get<object>("backdoor_result");
            var stringResult = (string) result;
            stringResult.ShouldBe(text);
        }
    }
}