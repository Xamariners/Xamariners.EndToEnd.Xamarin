using System;
using System.IO;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public partial class ScreenQueries
    {
        public FileInfo SaveScreenshot(string path, string title)
        {
            var screenshot = App.Screenshot(title);

            try
            {
                var fullPath = Path.Combine(path, $"{DateTime.Now:yyyy-MM-dd_HH.mm.ss.fff}_{title}.png");
                screenshot.CopyTo(fullPath);
            }
            catch (Exception)
            {
                // ignored
            }
            return screenshot;
        }
    }
}