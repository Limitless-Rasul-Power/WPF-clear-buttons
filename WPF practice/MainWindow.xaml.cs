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

namespace WPF_practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();
        private const int StackPanelSecondFirstButtonUID = 4;
        private const int ClearAllButtonUID = 0;
        public MainWindow()
        {
            InitializeComponent();
        }  

        private void Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Color randomColor = Color.FromRgb((byte)_random.Next(0, 255), (byte)_random.Next(0, 255), (byte)_random.Next(0, 255));
                button.Background = new SolidColorBrush(randomColor);
                MessageBox.Show($"My number is {button.Content}", "Information about button", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                Title = $"Button Content  \"{button.Content}\" is Deleted.";

                int buttonUID = Convert.ToInt32(button.Uid);

                if (buttonUID == ClearAllButtonUID)
                {
                    MainGrid.Children.Clear();
                }
                else if (buttonUID < StackPanelSecondFirstButtonUID)
                {
                    StackPanelFirst.Children.Remove(button);
                }
                else
                {
                    StackPanelSecond.Children.Remove(button);
                }
            }
        }

    }
}
