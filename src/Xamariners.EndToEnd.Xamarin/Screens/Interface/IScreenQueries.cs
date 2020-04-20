using System.IO;
using Xamarin.UITest.Queries;

namespace Xamariners.EndToEnd.Xamarin.Screens.Interface
{
    public interface IScreenQueries
    {
        AppResult[] WaitForElementMarked(string mark, string timeoutMessage = "not found", int timeout = 5);
        AppResult[] WaitForButtonMarked(string mark, string timeoutMessage, int timeout);
        AppResult[] WaitForEntry(string text, string timeoutMessage, int timeout);

        void ValidateLabelText(string text);
        void ValidateLabelText(string marked, string text);
        void ValidateLabelMarked(string mark);

        void ValidateWindowMarked(string mark);

        void ValidateEntry(string mark);
        void ValidateEntryText(string text);
        void ValidateEntryText(string marked, string text);

        void ValidateButtonMarked(string mark);
        void ValidateButtonText(string text);
        void ValidateButtonText(string marked, string text);

        void EnterTextOnElementMarked(string mark, string text);

        void TapOnElementMarked(string mark);

        void TapOnButtonMarked(string mark);
        void TapOnButtonMarked(string mark, int index);

        void ValidateMessageContainingText(string text);
       
        void NavigateBack();

        FileInfo SaveScreenshot(string path, string title);

    }
}
