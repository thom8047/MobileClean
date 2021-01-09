using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;

//note

namespace Mobile
{
    class Display
    {
        public string button_color = "#CD5C5C";
        public string back_button_color = "#CD5C5C";
        public List<ButtonData> GetButtonData()
        {
            var obj = new Reader();
            var button_data = obj.CSV();
            return button_data;
        }
        public StackLayout ReturnStack(List<Button> buttons)
        {
            //Specific csv that has only the button data that we want to put in stack and return that stack to put in the content.
            var stack = new StackLayout();

            foreach (var button in buttons)
            {
                stack.Children.Add(button);
            }/*
            var scroll = new ScrollView
            {
                Content = stack
            };
            */
            return stack;
        }

        public StackLayout GetButtons(string form_name, StackLayout main, ScrollView scroll)
        {
            var DisplayObject = new Display();

            var button_data = DisplayObject.GetButtonData();
            var button_list = new List<Button>();

            foreach (var piece in button_data)
            {
                if (piece.FormName == form_name)
                {
                    var button = new Button
                    {
                        // Physical look of buttons
                        Text = piece.ButtonName,
                        FontSize = 32,
                        VerticalOptions = LayoutOptions.Center,
                        CornerRadius = 0,
                        BackgroundColor = Color.FromHex(button_color),
                        TextColor = Color.White,
                    };
                    button.Clicked += async (s, e) =>
                    {
                        await Browser.OpenAsync(piece.Link);
                    };
                    button_list.Add(button);
                }
            }

            var BackButton = new Button
            {
                Text = "Back",
                FontSize = 32,
                VerticalOptions = LayoutOptions.Center,
                CornerRadius = 0,
                BackgroundColor = Color.DarkGray,
            };
            BackButton.Clicked += (s, e) =>
            {
                DisplayObject.GetMainPage(scroll, main);
            };

            button_list.Add(BackButton);
            var GetStack = DisplayObject.ReturnStack(button_list);

            return GetStack;
        }

        public StackLayout GetSubPage(string form_name, StackLayout main, ScrollView scroll)
        {
            var DisplayObject = new Display();
            var GetStack = DisplayObject.GetButtons(form_name, main, scroll);

            return GetStack;
        }
        public void GetMainPage(ScrollView scroll, StackLayout main)
        {
            var DisplayObject = new Display();

            var button_data = DisplayObject.GetButtonData();
            var categories = button_data.Select(x => x.FormName).Distinct().ToList();
            var category = new List<Button>();

            foreach (var str in categories)
            {
                var category_button = new Button
                {
                    Text = str,
                    FontSize = 32,
                    VerticalOptions = LayoutOptions.Center,
                    CornerRadius = 0,
                    BackgroundColor = Color.FromHex(button_color),
                    TextColor = Color.White,
                };
                category_button.Clicked += (s, e) =>
                {
                    var sub = DisplayObject.GetSubPage(category_button.Text, main, scroll);
                    scroll.Content = sub;
                };

                category.Add(category_button);
            }

            var GetStack = DisplayObject.ReturnStack(category);
            scroll.Content = GetStack;
        }
    }
}
