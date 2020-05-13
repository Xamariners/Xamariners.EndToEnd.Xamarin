using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryAndLabelPage : ContentPage
    {
        public EntryAndLabelPage()
        {
            InitializeComponent();
        }

        private void TextButton_OnClicked(object sender, EventArgs e)
        {
            TextLabel.Text = TextEntry.Text;
        }
    }
}