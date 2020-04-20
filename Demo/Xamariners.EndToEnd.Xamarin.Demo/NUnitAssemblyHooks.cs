﻿using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Xamariners.EndToEnd.Xamarin.Demo
{
    [SetUpFixture]
    public class NUnitAssemblyHooks
    {
        [OneTimeSetUp]
        public void AssemblyInitialize()
        {
            var currentAssembly = typeof(NUnitAssemblyHooks).Assembly;

            TestRunnerManager.OnTestRunStart(currentAssembly);
        }

        [OneTimeTearDown]
        public void AssemblyCleanup()
        {
            var currentAssembly = typeof(NUnitAssemblyHooks).Assembly;

            TestRunnerManager.OnTestRunEnd(currentAssembly);
        }
    }
}