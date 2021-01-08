using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public void Display()
        {
            // Figure it out.
        }
        public MainPage()
        {
            //InitializeComponent();
            Label label = new Label
            {
                Text = "Brighten The Brain",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
            };

            Frame frame = new Frame
            {
                Content = label,
                Padding = 24,
                BackgroundColor = Color.Black,
            };
            var stack = new StackLayout();
            var scroll = new ScrollView();
            stack.BackgroundColor = Color.FromHex("#424242");
            Content = stack;
            stack.Children.Add(frame);
            stack.Children.Add(scroll);


            //Get DisplayObject and get buttons

            var DisplayObject = new Display();
            DisplayObject.GetMainPage(scroll, stack);
        }
    }
}
