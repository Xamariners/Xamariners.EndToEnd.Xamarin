using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Features;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.Demo
{
    [SetUpFixture]
    public class NUnitAssemblyHooks : NUnitAssemblyHooksBase
    {
        static NUnitAssemblyHooks()
        {
            RunnerConfiguration.CurrentAssembly = typeof(NUnitAssemblyHooks).Assembly;
        }
    }
}