//Name:MainWindow.xaml.cs
//Purpose: Establishes back logic for main window 
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Management_Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool logCheck = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (logCheck)
            {
                UserBox.Text = "Not logged in";
                Login_Button.Content = "Login or Sign Up";
                logCheck = false;
            }
            else
            {
                LoginWindow log = new LoginWindow();
                log.Owner = this;
                log.ShowDialog();
                if (log.DialogResult.HasValue && log.DialogResult.Value)
                {
                    MessageBox.Show("Welcome " + log.UserBox.Text);
                    UserBox.Text = "Logged in as " + log.UserBox.Text;
                    logCheck = true;
                    Login_Button.Content = "Logout";
                }
            }
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow();
            set.Owner = this;
            set.ShowDialog();
            if(set.DialogResult.HasValue && set.DialogResult.Value)
            {
                if(set.BlockColor != null)
                {
                    
                }
            }
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AccessDb_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DatabaseWindow data = new DatabaseWindow();
            data.Owner = this;
            data.ShowDialog();
            if(data.DialogResult.HasValue)
            {
                this.Show();
            }
        }
    }
}
