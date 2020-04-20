using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonCountPage : ContentPage
    {
        private int _count;

        public ButtonCountPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            _count++;
            ClickCountLabel.Text = $"You clicked {_count} times on the button";
        }
    }
}