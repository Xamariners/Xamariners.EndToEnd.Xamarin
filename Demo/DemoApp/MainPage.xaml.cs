using System;

namespace DemoApp
{
    public partial class MainPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClickCountPage());
        }
        private void Button_OnClicked2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntryToLabelPage());
        }
      
    }
}
