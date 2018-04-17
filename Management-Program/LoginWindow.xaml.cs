//Name: LoginWindow.xaml.cs
//Purpose: Adds interaction logic for the login page
//Author: Brayden Faulkner
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

    public static class MyExt
    {
        public static void PerformClick(this Button btn)
        {
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(UserBox.Text))
            {
                MessageBox.Show("Please enter your username.", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                UserBox.Focus();
                return;
            }
            try
            {
                LoginDataSetTableAdapters.UsersTableAdapter user = new LoginDataSetTableAdapters.UsersTableAdapter();
                LoginDataSet.UsersDataTable dt = user.GetDataByUsernamePassword(UserBox.Text, PassBox.Text);
                UserBox.Focus();
                if(dt.Rows.Count > 0)
                {
                    DialogResult = true;
                    MessageBox.Show("You have been succesfully logged in.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your username or password is incorrect.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                UserBox.Focus();
        }

        private void PassBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                LoginButton.PerformClick();
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PassBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
