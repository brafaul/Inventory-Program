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
using System.Windows.Shapes;

namespace Management_Program
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SolidColorBrush WinColor;
        public string BlockColor;
        public SettingsWindow(string B, SolidColorBrush W)
        {
            BlockColor = B;
            WinColor = W;
            InitializeComponent();
            if (B == "Snow")
                ListLabel.Content = "Default";
            else
                ListLabel.Content = B;

            if (W == Brushes.Snow)
                WindowLabel.Content = "Default";
            else if (W == Brushes.White)
                WindowLabel.Content = "White";
            else if (W == Brushes.Red)
                WindowLabel.Content = "Red";
            else if (W == Brushes.Blue)
                WindowLabel.Content = "Blue";
            else if (W == Brushes.Green)
                WindowLabel.Content = "Green";
            else if (W == Brushes.Gray)
                WindowLabel.Content = "Gray";
            else if (W == Brushes.Yellow)
                WindowLabel.Content = "Yellow";
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void DropBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "White";
            DropBox.IsDropDownOpen = false;
            ListLabel.Content = "White";
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Red";
            DropBox.IsDropDownOpen = false;
            ListLabel.Content = "Red";
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Blue";
            DropBox.IsDropDownOpen = false;
            ListLabel.Content = "Blue";
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Green";
            DropBox.IsDropDownOpen = false;
            ListLabel.Content = "Green";
        }

        private void Gray_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Gray";
            DropBox.IsDropDownOpen = false;
            ListLabel.Content = "Gray";
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Yellow";
            DropBox.IsDropDownOpen = false;
            ListLabel.Content = "Yellow";
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Snow";
            DropBox.IsDropDownOpen = false;
            ListLabel.Content = "Default";
        }

        private void DropBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                DropBox.IsDropDownOpen = true;
            }
            else if(e.Key == Key.Escape)
            {
                DropBox.IsDropDownOpen = false;
            }
        }

        private void WWhite_Click(object sender, RoutedEventArgs e)
        {
            WinColor = Brushes.White;
            this.Background = WinColor;
            WindowBox.IsDropDownOpen = false;
            WindowLabel.Content = "White";
        }

        private void WRed_Click(object sender, RoutedEventArgs e)
        {
            WinColor = Brushes.Red;
            this.Background = WinColor;
            WindowBox.IsDropDownOpen = false;
            WindowLabel.Content = "Red";
        }

        private void WBlue_Click(object sender, RoutedEventArgs e)
        {
            WinColor = Brushes.Blue;
            this.Background = WinColor;
            WindowBox.IsDropDownOpen = false;
            WindowLabel.Content = "Blue";
        }

        private void WGreen_Click(object sender, RoutedEventArgs e)
        {
            WinColor = Brushes.Green;
            this.Background = WinColor;
            WindowBox.IsDropDownOpen = false;
            WindowLabel.Content = "Green";
        }

        private void WGray_Click(object sender, RoutedEventArgs e)
        {
            WinColor = Brushes.Gray;
            this.Background = WinColor;
            WindowBox.IsDropDownOpen = false;
            WindowLabel.Content = "Gray";
        }

        private void WYellow_Click(object sender, RoutedEventArgs e)
        {
            WinColor = Brushes.Yellow;
            this.Background = WinColor;
            WindowBox.IsDropDownOpen = false;
            WindowLabel.Content = "Yellow";
        }

        private void WDefault_Click(object sender, RoutedEventArgs e)
        {
            WinColor = Brushes.Snow;
            this.Background = WinColor;
            WindowBox.IsDropDownOpen = false;
            WindowLabel.Content = "Default";
        }
    }
}
