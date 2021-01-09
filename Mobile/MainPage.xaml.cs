using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public string frame_background_color = "#424242";
        public string main_background_color = "#F7F9F9";
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
                TextColor = Color.FromHex(main_background_color),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
            };

            Frame frame = new Frame
            {
                Content = label,
                Padding = 24,
                BackgroundColor = Color.Black,
            };
            var scroll = new ScrollView
            {
                BackgroundColor = Color.FromHex(frame_background_color),//("#424242");
                Padding = new Thickness(10, 10)
            };

            var stack = new StackLayout();
            stack.BackgroundColor = Color.FromHex(frame_background_color);

            stack.Children.Add(frame);
            stack.Children.Add(scroll);

            Content = stack;

            //Get DisplayObject and get buttons

            var DisplayObject = new Display();
            DisplayObject.GetMainPage(scroll, stack);
        }
    }
}
