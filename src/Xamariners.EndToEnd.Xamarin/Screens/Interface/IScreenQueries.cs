using System.IO;
using Xamarin.UITest.Queries;

namespace Xamariners.EndToEnd.Xamarin.Screens.Interface
{
    public interface IScreenQueries
    {
        AppResult[] WaitForEntry(string text, string timeoutMessage, int timeout);
        void ValidateEntry(string mark);
        void ValidateEntryText(string text);
        void ValidateEntryText(string mark, string text);
        void EnterTextOnElementMarked(string mark, string text, bool clear = true);
        AppResult[] WaitForButtonMarked(string mark, string timeoutMessage, int timeout);
        void ValidateButtonMarked(string mark);
        void ValidateButtonText(string text);
        void ValidateButtonText(string mark, string text);
        void TapOnElementMarked(string mark);
        void TapOnButtonMarked(string mark);
        void TapOnButtonMarked(string mark, int index);
        AppResult[] WaitForElementMarked(string mark, string timeoutMessage = "not found", int timeout = 5);
        void Wait(string mark);
        void WaitForNo(string mark);
        void WaitForNoElementMarked(string mark, string timeoutMessage = "not found", int timeout = 5);
        void WaitAll(string mark);
        void ValidateLabelText(string text);
        void ValidateLabelText(string mark, string text);
        void ValidateLabelMarked(string mark);
        void ValidateMessageContainingText(string text);
        void ScrollDownToMarked(string mark);
        void ScrollUpToMarked(string mark);
        void ScrollToMarked(string mark);
        FileInfo SaveScreenshot(string path, string title);
        void NavigateBack();
        void ValidateWindowMarked(string mark);
        void WaitWebView();
        void ManualWebViewScroll(float ratioFromY, float ratioToY);
        void ScrollWebViewDown(string mark = null);
        void ScrollWebViewUp(string mark = null);
        string WebViewGetUserAgent();
        void WebViewFlashElement(string mark);
        void DoubleTapOnButtonMarked(string mark);
        void DragAndDropFromElementToElement(string fromMark, string toMark);
        void Flash(string mark);
        void WhenITapOnMasterDetailHamburger();
    }
}