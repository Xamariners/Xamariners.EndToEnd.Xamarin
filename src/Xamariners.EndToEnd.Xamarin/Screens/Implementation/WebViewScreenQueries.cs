using System;
using System.Linq;
using System.Threading;
using Xamarin.UITest;

namespace Xamariners.EndToEnd.Xamarin.Screens.Implementation
{

    public partial class ScreenQueries
    {
        public void WaitWebView()
        {
            App.WaitForElement(a => a.WebView(), "Timed out waiting for webView", DefaultTimeout);
        }
        public void ManualWebViewScroll(float ratioFromY, float ratioToY)
        {
            var webView = App.Query(y => y.WebView()).FirstOrDefault();

            if (webView == null) return;
            var fromX = webView.Rect.CenterX;
            var fromY = (webView.Rect.Y + webView.Rect.Height) * ratioFromY;
            var toX = webView.Rect.CenterX;
            var toY = (webView.Rect.Y + webView.Rect.Height) * ratioToY;
            App.DragCoordinates(fromX, fromY, toX, toY);
        }

        public void ScrollWebViewDown(string mark = null)
        {
            if (mark == null)
                App.ScrollDown(y => y.WebView(), ScrollStrategy.Gesture);
            else
                App.ScrollDownTo(x => UseXPath(mark) ? x.XPath(mark) : x.Css(mark), y => y.WebView(), ScrollStrategy.Gesture);
        }

        public void ScrollWebViewUp(string mark = null)
        {
            if (mark == null)
                App.ScrollUp(y => y.WebView(), ScrollStrategy.Gesture);
            else
                App.ScrollUpTo(x => UseXPath(mark) ? x.XPath(mark) : x.Css(mark), y => y.WebView(), ScrollStrategy.Gesture);
        }

        public string WebViewGetUserAgent()
        {
            WaitWebView();
            var query = App.Query(a => a.WebView().InvokeJS("return navigator.userAgent;"));
            return (query != null ? string.Join(Environment.NewLine, query) : null);
        }

        public void WebViewFlashElement(string mark)
        {
            WaitWebView();
            var elementGetter = string.Format(
                UseXPath(mark) ?
                    "document.evaluate('{0}', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue" :
                    "document.getElementById('{0}')",
                mark);

            App.Query(a =>
                a.WebView().InvokeJS(
                    string.Format(@"
var element = {0};
element.style.visibility='hidden';
setTimeout(function(){{
    element.style.visibility = 'visible';
    setTimeout(function(){{
        element.style.visibility = 'hidden';
        setTimeout(function(){{
            element.style.visibility = 'visible';
            setTimeout(function(){{
                element.style.visibility = 'hidden';
                setTimeout(function(){{
                    element.style.visibility = 'visible';
                }},({1}));
            }},({1}));
        }},({1}));
    }},({1}));
}},({1}));
", elementGetter, 500)
                )
            );
            Thread.Sleep(2500);
        }
    }
}