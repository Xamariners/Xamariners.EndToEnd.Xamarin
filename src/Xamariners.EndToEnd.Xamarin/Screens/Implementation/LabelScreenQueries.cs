using Shouldly;
using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Screens.Interface;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public partial class ScreenQueries : IScreenQueries
    {

        public void ValidateLabelText(string text)
        {
            var result = WaitForElementMarked(text, $"'{text}' does not exist", 30);
            result[0].Text.ShouldContain(text);
        }

        public void ValidateLabelText(string mark, string text)
        {
            var result = WaitForElementMarked(mark, $"'{mark}' does not exist", 30);
            result[0].Text.ShouldContain(text);
        }

        public void ValidateLabelMarked(string mark)
        {
            var result = WaitForElementMarked(mark, $"'{mark}' does not exist", 30);
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);

            var validationMark = _platform == Platform.Android ? result[0].Label : result[0].Id;
            validationMark.ShouldBe(mark);
        }

        public void ValidateMessageContainingText(string text)
        {
            var result = WaitForElementMarked(text, $"label containing '{text}' does not exist", 30);
            result[0].Text.ShouldContain(text);
        }
    }
}