using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CW_03_Properties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                double size;
                if (double.TryParse(button.Content.ToString()?.Substring
                    (button.Content.ToString().LastIndexOf(' ') + 1),out size))
                {
                    FontSize = size;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                double size;
                if (double.TryParse(button.Name.ToString()?.Substring
                    (button.Name.ToString().LastIndexOf('_') + 1), out size))
                {
                    button.FontSize = size;
                }
            }
        }

        private void SpaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is SpaceButton button)
            {
                button.Space = Convert.ToInt32(button.Tag);
            }
        }
    }
}
