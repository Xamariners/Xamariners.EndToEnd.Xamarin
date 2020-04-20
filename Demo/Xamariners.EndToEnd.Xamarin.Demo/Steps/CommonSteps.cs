using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Xamariners.EndToEnd.Xamarin.Demo.Steps
{
    [Binding]
    public class CommonSteps : SharedSteps.CommonSteps
    {
        public static string Screenshot_Path = @"C:\Screenshots";
        public static Guid Test_Run = Guid.NewGuid();

        public CommonSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            if (!Directory.Exists($@"{Screenshot_Path}\{Test_Run}"))
                Directory.CreateDirectory($@"{Screenshot_Path}\{Test_Run}");
            
            ScreenshotPath = $@"{Screenshot_Path}\{Test_Run}";
        }
    }
}