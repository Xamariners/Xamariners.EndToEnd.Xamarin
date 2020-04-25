using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryToLabelPage : ContentPage
    {
        public EntryToLabelPage()
        {
            InitializeComponent();
        }

        private void TextButton_OnClicked(object sender, EventArgs e)
        {
            if (TextEntry.Text.ToLower() == "error")
            {
                var properties = new Dictionary<string, string>
                {
                    { "Context", "Gab 2020" },
                    { "User", "Ben"}
                };

                Crashes.TrackError(new Exception("Ben Exception"), properties);
            }
            else if(TextEntry.Text.ToLower() == "crash")
            {
                int zero = 0;
                int notGood = 5 / zero;
            }

            TextLabel.Text = TextEntry.Text;
        }
    }
}