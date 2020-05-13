using NUnit.Framework;
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