using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Xamariners.EndToEnd.Xamarin.Infrastructure
{
    public class NUnitAssemblyHooksBase
    {
        [OneTimeSetUp]
        public virtual void AssemblyInitialize()
        {
            if (RunnerConfiguration.CurrentAssembly == null)
                throw new Exception("Please set RunnerConfiguration.CurrentAssembly before calling this method");

            TestRunnerManager.OnTestRunStart(RunnerConfiguration.CurrentAssembly);
        }

        [OneTimeTearDown]
        public virtual void AssemblyCleanup()
        {
            if (RunnerConfiguration.CurrentAssembly == null)
                throw new Exception("Please set RunnerConfiguration.CurrentAssembly before calling this method");

            TestRunnerManager.OnTestRunEnd(RunnerConfiguration.CurrentAssembly);
        }
    }
}