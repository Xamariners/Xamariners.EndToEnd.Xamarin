using System;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Models;
using Xamariners.EndToEnd.Xamarin.Screens.Implementation;
using Xamariners.EndToEnd.Xamarin.Screens.Interface;

namespace Xamariners.EndToEnd.Xamarin.Features
{
    public class BaseFeature
    {
        protected readonly Platform Platform;
        public static IApp App;
        public static IScreenQueries ScreenQueries;
        protected IBaseAppInitializer BaseAppInitializer;
        protected RunnerConfiguration ConfigurationReader;
        private bool _isLocal;
        private string _configurationFile;

        protected string ConfigurationFile
        {
            get => _configurationFile;
            set
            {
                _configurationFile = value;
                if (string.IsNullOrWhiteSpace(_configurationFile))  return;

                var resourceFile = FormatResourceName(Assembly.GetCallingAssembly(), _configurationFile);
                using (var stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resourceFile))
                {
                    if (stream == null) return;
                    
                    _isLocal = true;
                    var reader = new StreamReader(stream);
                    var jsonFile = reader.ReadToEnd();
                    ConfigurationReader = new RunnerConfiguration(jsonFile);
                }
            }
        }

        public BaseFeature(Platform platform)
        {
            Platform = platform;
            ScreenQueries = new ScreenQueries(platform);
        }

        private string FormatResourceName(Assembly assembly, string resourceName)
        {
            resourceName = assembly.GetName()
                               .Name + "." + resourceName.Replace(" ", "_")
                               .Replace("\\", ".").Replace("/", ".");

            var resourceNames = assembly.GetManifestResourceNames();

            var resourcePaths = resourceNames
                .Where(x => x.EndsWith(resourceName, StringComparison.CurrentCultureIgnoreCase))
                .ToArray();

            if (!resourcePaths.Any())
                throw new Exception($"Resource ending with {resourceName} not found.");

            if (resourcePaths.Length > 1)
                throw new Exception(
                    $"Multiple resources ending with {resourceName} found: \n{string.Join(Environment.NewLine, resourcePaths)}");

            return resourcePaths.Single();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            if (_isLocal)
            {
                App = BaseAppInitializer.StartApp(Platform, ConfigurationReader);
                return;
            }

            App = BaseAppInitializer.StartApp(Platform);
        }
    }
}