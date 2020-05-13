using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamariners.EndToEnd.Xamarin.Infrastructure;
using Xamariners.EndToEnd.Xamarin.Screens.Interface;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public partial class ScreenQueries : IScreenQueries
    {
        private IApp App => RunnerConfiguration.Current.App;
        private readonly Platform _platform;
        private static readonly TimeSpan DefaultTimeout = new TimeSpan(0, 0, 30);

        private static bool UseXPath(string s)
        {
            return s.StartsWith("/");
        }

        public ScreenQueries(Platform platform)
        {
            _platform = platform;
        }

        public AppResult[] WaitForElementMarked(string mark, string timeoutMessage = "not found", int timeout = 5)
        {
            return App.WaitForElement(mark, timeoutMessage, TimeSpan.FromSeconds(timeout));
        }

        public void WaitForNoElementMarked(string mark, string timeoutMessage = "not found", int timeout = 5)
        {
             App.WaitForNoElement(mark, timeoutMessage, TimeSpan.FromSeconds(timeout));
        }

        public void Wait(string mark)
        {
            App.WaitForElement(x => UseXPath(mark) ? x.XPath(mark) : x.Css(mark), "Timed out waiting for element...", DefaultTimeout);
        }

        public void WaitForNo(string mark)
        {
            App.WaitForNoElement(x => UseXPath(mark) ? x.XPath(mark) : x.Css(mark), "Timed out waiting for no element...", DefaultTimeout);
        }

        public void WaitAll(string mark)
        {
            App.WaitForElement(x => UseXPath(mark) ? x.All().XPath(mark) : x.All().Css(mark), "Timed out waiting for element...", DefaultTimeout);
        }

        public void Flash(string mark)
        {
            WaitForElementMarked(mark);
            App.Flash(mark);
        }
    }
}