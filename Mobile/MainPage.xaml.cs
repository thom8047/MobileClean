using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public void getButtons()
        {
            /* Change in the Reader class to create a button with every read, the text of the button and the content or link of 
            button and append to a list of buttons that gets returned. With this returned list we can put each button inside a 
            scroll view and from there see if it'll open with the Open class I wrote in.*/
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
            var scrollStack = new StackLayout();
            scroll.Content = scrollStack;
            stack.BackgroundColor = Color.FromHex("#424242");
            Content = stack;
            stack.Children.Add(frame);
            stack.Children.Add(scroll);

            // Let's get Buttons
            var obj = new Reader();
            var button_data = obj.CSV();

            foreach (var piece in button_data)
            {
                var button = new Button
                {
                    // Physical look of buttons
                    Text = piece.ButtonName,
                    FontSize = 32,
                    VerticalOptions = LayoutOptions.Center,
                    CornerRadius = 0,
                    BackgroundColor = Color.FromHex("#42D7D6"),
                    TextColor = Color.White,
                };
                button.Clicked += async (s, e) =>
                {
                    await Browser.OpenAsync(piece.Link);
                };
                scrollStack.Children.Add(button);
            }
        }
    }
}
