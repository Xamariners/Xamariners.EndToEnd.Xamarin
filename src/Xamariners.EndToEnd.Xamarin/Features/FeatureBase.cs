using NUnit.Framework;
using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Infrastructure;
using Xamariners.EndToEnd.Xamarin.Screens.Implementation;

namespace Xamariners.EndToEnd.Xamarin.Features
{
    public class FeatureBase
    {
        protected IBaseAppInitializer BaseAppInitializer;
        
        public FeatureBase(Platform platform)
        {
            RunnerConfiguration.Platform = platform;

            if (!RunnerConfiguration.IsAppCenterTest)
                RunnerConfiguration.GetInstance();
       
            BaseAppInitializer = new BaseAppInitializer();

            RunnerConfiguration.Current.ScreenQueries = new ScreenQueries(RunnerConfiguration.Platform);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            if (!RunnerConfiguration.IsAppCenterTest)
            {
                RunnerConfiguration.Current.App = BaseAppInitializer.StartApp(RunnerConfiguration.Platform, RunnerConfiguration.Current);
                return;
            }
            
           RunnerConfiguration.Current.App = BaseAppInitializer.StartApp(RunnerConfiguration.Platform);
        }
    }
}