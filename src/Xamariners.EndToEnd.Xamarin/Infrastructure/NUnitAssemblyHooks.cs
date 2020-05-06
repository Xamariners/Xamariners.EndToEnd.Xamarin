using System;
using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Xamariners.EndToEnd.Xamarin.Infrastructure
{
    public class NUnitAssemblyHooksBase
    {
        protected static Assembly CurrentAssembly { get; set; }

        [OneTimeSetUp]
        public virtual void AssemblyInitialize()
        {
            if(CurrentAssembly == null)
                throw new Exception("Please set CurrentAssembly before calling this method");

            TestRunnerManager.OnTestRunStart(CurrentAssembly);
        }

        [OneTimeTearDown]
        public virtual void AssemblyCleanup()
        {
            if (CurrentAssembly == null)
                throw new Exception("Please set CurrentAssembly before calling this method");

            TestRunnerManager.OnTestRunEnd(CurrentAssembly);
        }
    }
}