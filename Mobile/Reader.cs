using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Xamarin.Forms;

namespace Mobile
{
    public class ButtonData
    {
        public string FormName { get; set; }
        public string ButtonName { get; set; }
        public string Link { get; set; }
        public ButtonData ReturnButton(string form_name, string button_name, string link)
        {
            ButtonData button = new ButtonData
            {
                FormName = form_name,
                ButtonName = button_name,
                Link = link,
            };

            return button;
        }
    }
    public class Reader
    {
        public List<ButtonData> CSV()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Reader)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Mobile.DataBase.csv");

            using (var reader = new StreamReader(stream))
            {
                var list_of_buttons = new List<ButtonData>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    ButtonData data = new ButtonData
                    {
                        FormName = values[0],
                        ButtonName = values[1],
                        Link = values[2]
                    };

                    list_of_buttons.Add(data);
                }

                return list_of_buttons;
            }
        }
    }
}
