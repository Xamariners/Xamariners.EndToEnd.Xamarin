using Newtonsoft.Json;

namespace Xamariners.EndToEnd.Xamarin.Models
{
    public class RunnerConfiguration
    {
        public bool Repl { get; set; }
        public AndroidConfiguration AndroidConfiguration { get; set; }
        public IosConfiguration IosConfiguration { get; set; }

        public RunnerConfiguration(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                Build(json);
            }
        }

        private void Build(string json)
        {
            var temp = JsonConvert.DeserializeObject<RunnerConfiguration>(json);
            Repl = temp.Repl;
            AndroidConfiguration = temp.AndroidConfiguration;
            IosConfiguration = temp.IosConfiguration;
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