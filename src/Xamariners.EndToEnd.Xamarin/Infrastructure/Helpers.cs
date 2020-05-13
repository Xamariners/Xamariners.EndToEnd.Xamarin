using System;
using System.Linq;
using System.Reflection;

namespace Xamariners.EndToEnd.Xamarin.Infrastructure
{
    public static class Helpers
    {
        public static string FormatResourceName(Assembly assembly, string resourceName)
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
    }
}
