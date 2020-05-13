using Shouldly;
using Xamarin.UITest;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public partial class ScreenQueries
    {
        public void NavigateBack()
        {
            App.Back();
        }

        public void ValidateWindowMarked(string mark)
        {
            var result = WaitForElementMarked(mark, $"'{mark}' does not exist", 60);

            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);

            var validationMark = _platform == Platform.Android ? result[0].Text : result[0].Id;
            validationMark.ShouldBe(mark);
        }
    }
}