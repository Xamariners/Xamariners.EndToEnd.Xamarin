using System;
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
            TextLabel.Text = TextEntry.Text;
        }
    }
}