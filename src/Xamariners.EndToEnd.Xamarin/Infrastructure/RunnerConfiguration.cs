using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Screens.Interface;

namespace Xamariners.EndToEnd.Xamarin.Infrastructure
{
    public class RunnerConfiguration
    {
        private const string ConfigurationFile = "TestConfig.json";
        public static Assembly CurrentAssembly { get; set; }
        public static bool IsAppCenterTest => Environment.GetEnvironmentVariable("APP_CENTER_TEST") == "1";
        public static Platform Platform { get; set; }

        public IApp App;
        public IScreenQueries ScreenQueries;

        public bool Repl { get; set; }
        public bool EnableScreenshots { get; private set; } = true;
        public string ScreenshotsRoot { get; private set; } = @"C:\Screenshots";
        public string ScreenshotsPath { get; private set; }
        public Guid TestRunId { get; private set; }

        public AndroidConfiguration AndroidConfiguration { get; set; }
        public IosConfiguration IosConfiguration { get; set; }

        public static RunnerConfiguration Current { get; private set; }

        public static RunnerConfiguration GetInstance()
        {
            if (Current != null)
                return Current;

            if (CurrentAssembly == null) return null;

            var resourceFile = Helpers.FormatResourceName(CurrentAssembly, ConfigurationFile);

            using (var stream = CurrentAssembly.GetManifestResourceStream(resourceFile))
            {
                if (stream == null) return null;

                var reader = new StreamReader(stream);
                var jsonFile = reader.ReadToEnd();
                Current = new RunnerConfiguration(jsonFile);
            }

            return Current;
        }

        public RunnerConfiguration(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
                Build(json);
        }

        private void Build(string json)
        {
            var config = JsonConvert.DeserializeObject<RunnerConfiguration>(json);
            Repl = config.Repl;
            AndroidConfiguration = config.AndroidConfiguration;
            IosConfiguration = config.IosConfiguration;
            EnableScreenshots = config.EnableScreenshots;
            ScreenshotsRoot = config.ScreenshotsRoot;
            TestRunId = Guid.NewGuid();
            ScreenshotsPath =  $@"{ScreenshotsRoot}\{TestRunId}";

            if (EnableScreenshots)
            {
                if (!Directory.Exists(ScreenshotsPath))
                    Directory.CreateDirectory(ScreenshotsPath);
            }
        }
    }

    public class AndroidConfiguration
    {
        public string ApkName { get; set; }
        public string AppPath { get; set; }
    }

    public class IosConfiguration
    {
        public bool Simulator { get; set; }
        public string SimulatorIdentifier { get; set; }
        public string DeviceIdentifier { get; set; }
        public string BundleName { get; set; }
        public string AppName { get; set; }
        public string AppPath { get; set; }
    }
}