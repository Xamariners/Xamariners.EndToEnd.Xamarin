using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Features;

namespace Xamariners.EndToEnd.Xamarin.Demo.Features
{
    public class BaseLocalFeature : BaseFeature
    {
        public BaseLocalFeature(Platform platform) : base(platform)
        {
#if __LOCAL__
            ConfigurationFile = "testsConfiguration.json";
#endif
            BaseAppInitializer = new Infrastructure.BaseAppInitializer();
        }
    }
}