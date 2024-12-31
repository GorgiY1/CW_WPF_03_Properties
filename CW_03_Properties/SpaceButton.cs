using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CW_03_Properties
{
    class SpaceButton : Button
    {
        public int Space
        {
            get { return (int)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        private string _text;
        public string Text 
        { 
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                Content = SpaceOutText(_text);
            }
        }

        // Using a DependencyProperty as the backing store for Space. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpaceProperty;

        static SpaceButton()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata
            {
                DefaultValue = 1,
                AffectsMeasure = true,
                Inherits = true
            };
            metadata.PropertyChangedCallback += OnSpaseProperyChanged;

            SpaceProperty = DependencyProperty.Register("Space", typeof(int), typeof(SpaceButton),
                metadata,ValidateSpaceValue);
        }

        
        private static bool ValidateSpaceValue(object value)
        {
            return (int)value >= 0 && (int)value < 10;
        }

        private static void OnSpaseProperyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SpaceButton spaceButton)
            {
                spaceButton.Content = spaceButton.SpaceOutText(spaceButton.Text);
            }
        }

        private string SpaceOutText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }
            StringBuilder builder = new StringBuilder();

            foreach (char item in text)
            {
                builder.Append($"{item}{new string(' ', Space)}");
            }
            return builder.ToString();
        }
        //DependencyProperty.Register("Space", typeof(int), typeof(ownerclass), new PropertyMetadata(0));




    }
}
