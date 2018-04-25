//Name:MainWindow.xaml.cs
//Purpose: Establishes back logic for main window 
//Authors: Brayden Faulkner and Jon Sulcer
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
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace Management_Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool logCheck = false;
        string logInfo = null;
        string settingsColor = "Snow";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (logCheck)
            {
                LoginBox.Content = "Not logged in";
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
                    MessageBox.Show("Welcome back, " + log.UserBox.Text, "Message", MessageBoxButton.OK, MessageBoxImage.None);
                    LoginBox.Content = "Logged in as " + log.UserBox.Text;
                    logInfo = log.UserBox.Text;
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
                settingsColor = set.BlockColor;
            }
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AccessDb_Click(object sender, RoutedEventArgs e)
        {
            if (logCheck == true)
            {
                this.Hide();
                TDatabase database = new TDatabase();
                DataTable dt2 = new DataTable();

                try
                {
                    string currentItem = null;
                    string x;
                    string currentID = null;

                    string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Login.accdb";
                    OleDbConnection con = new OleDbConnection(conString);
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from " + logInfo + ";";
                    cmd.Connection = con;

                    OleDbCommand cmd2 = new OleDbCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from " + logInfo + ";";
                    cmd2.Connection = con;

                    con.Open();
                    OleDbDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        currentItem = read["Item"].ToString();
                        x = read["Quantity"].ToString();
                        currentID = read["ID"].ToString();
                        int currentQ = Int32.Parse(x);

                        database.AddObject(currentItem, currentQ, currentID);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd2);
                    adapter.Fill(dt2);

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                DatabaseWindow data = new DatabaseWindow(logInfo, database, settingsColor, dt2);
                data.Owner = this;
                data.ShowDialog();
                if (data.DialogResult.HasValue)
                {
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("You are not logged on.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
