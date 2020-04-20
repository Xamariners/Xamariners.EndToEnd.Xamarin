﻿using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Features;
using Xamariners.EndToEnd.Xamarin.Models;

namespace Xamariners.EndToEnd.Xamarin.Demo.Infrastructure
{
    public class BaseAppInitializer : IBaseAppInitializer
    {
        public IApp StartApp(Platform platform)
        {
            return AppInitializer.StartApp(platform);
        }

        public IApp StartApp(Platform platform, RunnerConfiguration configuration)
        {
            return AppInitializer.StartApp(platform, configuration);
        }
    }
}