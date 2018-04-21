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
        public string BlockColor;
        public SettingsWindow()
        {
            InitializeComponent();
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
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Red";
            DropBox.IsDropDownOpen = false;
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Blue";
            DropBox.IsDropDownOpen = false;
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Green";
            DropBox.IsDropDownOpen = false;
        }

        private void Gray_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Gray";
            DropBox.IsDropDownOpen = false;
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Yellow";
            DropBox.IsDropDownOpen = false;
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            BlockColor = "Snow";
            DropBox.IsDropDownOpen = false;
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
    }
}
