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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Password;
        public string Username;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Username = UserBox.Text;
        }

        private void PassBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = PassBox.Text;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            MessageBox.Show(Username + " " + Password);
        }
    }
}
