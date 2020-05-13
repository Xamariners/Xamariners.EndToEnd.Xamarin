using System;
using Shouldly;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamariners.EndToEnd.Xamarin.Screens.Interface;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public partial class ScreenQueries : IScreenQueries
    {

        public AppResult[] WaitForEntry(string text, string timeoutMessage, int timeout)
        {
            return App.WaitForElement(c => c.TextField(text), timeoutMessage, TimeSpan.FromSeconds(timeout));
        }
        
        public void ValidateEntry(string mark)
        {
            var result = WaitForEntry(mark, $"'{mark}' does not exist", 5);

            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);

            var validationMark = _platform == Platform.Android ? result[0].Label : result[0].Id;
            validationMark.ShouldBe(mark);
        }

        public void ValidateEntryText(string text)
        {
            var result = WaitForEntry(text, $"'{text}' does not exist", 5);

            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);

            result[0].Text.ShouldContain(text);
        }

        public void ValidateEntryText(string mark, string text)
        {
            var result = WaitForElementMarked(mark, $"'{mark}' does not exist", 30);
            result[0].Text.ShouldContain(text);
        }

        public void EnterTextOnElementMarked(string mark, string text, bool clear = false)
        {
            TapOnElementMarked(mark);

            if (clear)
            {
                App.ClearText(mark);
                App.DismissKeyboard();
            }

            App.EnterText(mark, text);
            App.DismissKeyboard();
        }
    }
}