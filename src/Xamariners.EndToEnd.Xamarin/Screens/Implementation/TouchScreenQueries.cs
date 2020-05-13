using System;
using Shouldly;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public partial class ScreenQueries
    {
        public AppResult[] WaitForButtonMarked(string mark, string timeoutMessage, int timeout)
        {
            return App.WaitForElement(c => c.Button(mark), timeoutMessage, TimeSpan.FromSeconds(timeout));
        }

        public void ValidateButtonMarked(string mark)
        {
            var result = WaitForButtonMarked(mark, $"'{mark}' does not exist", 5);

            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);

            var validationMark = _platform == Platform.Android ? result[0].Label : result[0].Id;
            validationMark.ShouldBe(mark);
        }

        public void ValidateButtonText(string text)
        {
            var result = WaitForButtonMarked(text, $"'{text}' does not exist", 5);

            if (result[0].Text != null)
                result[0].Text.ShouldBe(text);
            else
                result[0].Label.ShouldBe(text);
        }

        public void ValidateButtonText(string mark, string text)
        {
            var result = WaitForButtonMarked(mark, $"'{mark}' does not exist", 5);

            if (result[0].Text != null)
                result[0].Text.ShouldBe(text);
            else
                result[0].Label.ShouldBe(text);
        }

        public void TapOnElementMarked(string mark)
        {
            WaitForElementMarked(mark, $"'{mark}' does not exist", 5);

            // check if keyboard and dismiss it
            App.DismissKeyboard();

            App.Tap(mark);
        }

        public void TapOnButtonMarked(string mark)
        {
            WaitForButtonMarked(mark, $"'button {mark}' does not exist", 5);

            // check if keyboard and dismiss it
            App.DismissKeyboard();

            App.Tap(c => c.Button(mark));
        }

        public void DoubleTapOnButtonMarked(string mark)
        {
            WaitForButtonMarked(mark, $"'button {mark}' does not exist", 5);

            // check if keyboard and dismiss it
            App.DismissKeyboard();

            App.DoubleTap(c => c.Button(mark));
        }

        public void TapOnButtonMarked(string mark, int index)
        {
            WaitForButtonMarked(mark, $"'{mark}' does not exist", 5);
            if (index == -1)
                index = App.Query(c => c.Button().Marked(mark)).Length - 1;

            App.Tap(c => c.Button().Marked(mark).Index(index));
        }

        public void DragAndDropFromElementToElement(string fromMark, string toMark)
        {
            WaitForElementMarked(fromMark);
            WaitForElementMarked(toMark);
            
            App.DragAndDrop(fromMark, toMark);
        }
    }
}