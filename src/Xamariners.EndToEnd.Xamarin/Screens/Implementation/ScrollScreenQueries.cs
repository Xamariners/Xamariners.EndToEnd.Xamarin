using System.Linq;
using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Infrastructure;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public partial class ScreenQueries
    {
        public void ScrollDownToMarked(string mark)
        {
            if (RunnerConfiguration.Platform == Platform.iOS)
                App.ScrollDownTo(mark);
            else
                App.ScrollDownTo(mark, strategy: ScrollStrategy.Gesture);

            WaitForElementMarked(mark);
        }

        public void ScrollUpToMarked(string mark)
        {
            if (RunnerConfiguration.Platform == Platform.iOS)
                App.ScrollUpTo(mark);
            else
                App.ScrollUpTo(mark, strategy: ScrollStrategy.Gesture);

            WaitForElementMarked(mark);
        }

        public void ScrollToMarked(string mark)
        {
            if (RunnerConfiguration.Platform == Platform.iOS)
                App.ScrollTo(mark);
            else
                App.ScrollTo(mark, strategy: ScrollStrategy.Gesture);

            WaitForElementMarked(mark);
        }
    }
}