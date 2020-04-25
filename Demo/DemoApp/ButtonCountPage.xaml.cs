using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonCountPage : ContentPage
    {
        private int _count = 1;

        public ButtonCountPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            ClickCountLabel.Text = $"Clicked {_count++} times";
            Analytics.TrackEvent($"Button Clicked {_count} times");
        }
    }
}