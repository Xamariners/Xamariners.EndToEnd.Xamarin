using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Models;

namespace Xamariners.EndToEnd.Xamarin.Features
{
    public interface IBaseAppInitializer
    {
        IApp StartApp(Platform platform);
        IApp StartApp(Platform platform, RunnerConfiguration configuration);
    }
}