using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.Demo
{
    [SetUpFixture]
    public class NUnitAssemblyHooks : NUnitAssemblyHooksBase
    {
        static NUnitAssemblyHooks()
        {
            CurrentAssembly = typeof(NUnitAssemblyHooks).Assembly;
        }
    }
}