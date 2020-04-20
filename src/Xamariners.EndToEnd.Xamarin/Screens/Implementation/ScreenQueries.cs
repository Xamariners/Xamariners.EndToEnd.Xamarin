using System;
using System.IO;
using System.Linq;
using Shouldly;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamariners.EndToEnd.Xamarin.Features;
using Xamariners.EndToEnd.Xamarin.Screens.Interface;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public class ScreenQueries : IScreenQueries
    {

        private IApp App => BaseFeature.App;
        private readonly Platform _platform;


        public ScreenQueries(Platform platform)
        {
            _platform = platform;
        }

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

        public AppResult[] WaitForElementMarked(string mark, string timeoutMessage = "not found", int timeout = 5)
        {
            return App.WaitForElement(mark, timeoutMessage, TimeSpan.FromSeconds(timeout));
        }

        public AppResult[] WaitForButtonMarked(string mark, string timeoutMessage, int timeout)
        {
            return App.WaitForElement(c => c.Button(mark), timeoutMessage, TimeSpan.FromSeconds(timeout));
        }

        public AppResult[] WaitForEntry(string text, string timeoutMessage, int timeout)
        {
            return App.WaitForElement(c => c.TextField(text), timeoutMessage, TimeSpan.FromSeconds(timeout));
        }

        public void ValidateLabelText(string text)
        {
            var result = WaitForElementMarked(text, $"'{text}' does not exist", 30);
            result[0].Text.ShouldContain(text);
        }

        public void ValidateLabelText(string marked, string text)
        {
            var result = WaitForElementMarked(marked, $"'{marked}' does not exist", 30);
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

        public void ValidateWindowMarked(string mark)
        {
            var result = WaitForElementMarked(mark, $"'{mark}' does not exist", 60);

            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);

            var validationMark = _platform == Platform.Android ? result[0].Text : result[0].Id;
            validationMark.ShouldBe(mark);
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

        public void ValidateEntryText(string marked, string text)
        {
            var result = WaitForElementMarked(marked, $"'{marked}' does not exist", 30);
            result[0].Text.ShouldContain(text);
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

        public void ValidateButtonText(string marked, string text)
        {
            var result = WaitForButtonMarked(marked, $"'{marked}' does not exist", 5);

            if (result[0].Text != null)
                result[0].Text.ShouldBe(text);
            else
                result[0].Label.ShouldBe(text);
        }

        public void EnterTextOnElementMarked(string mark, string text)
        {
            TapOnElementMarked(mark);
            App.EnterText(mark, text);
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

        public void TapOnButtonMarked(string mark, int index)
        {
            WaitForButtonMarked(mark, $"'{mark}' does not exist", 5);
            if (index == -1)
                index = App.Query(c => c.Button().Marked(mark)).Length - 1;

            App.Tap(c => c.Button().Marked(mark).Index(index));
        }

        public void ValidateMessageContainingText(string text)
        {
            var result = WaitForElementMarked(text, $"label containing '{text}' does not exist", 30);
            result[0].Text.ShouldContain(text);
        }

        public void NavigateBack()
        {
            App.Back();
        }

    }
}