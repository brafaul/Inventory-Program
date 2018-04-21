//Name: RemoveWindow.xaml.cs
//Purpose: Adds interaction logic for RemoveWindow Window
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
using System.Data.OleDb;

namespace Management_Program
{
    /// <summary>
    /// Interaction logic for RemoveWindow.xaml
    /// </summary>
    public partial class RemoveWindow : Window
    {
        public TDatabase database;
        string RemName = null;
        bool NameCheck = false;
        string logInfo = null;
        public RemoveWindow(string log)
        {
            InitializeComponent();
        }
        public RemoveWindow(TDatabase D, string log)
        {
            database = D;
            logInfo = log;
            InitializeComponent();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameCheck == true)
            {
                DialogResult = true;
                RemName = RemNameBox.Text;

                try
                {
                    string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Login.accdb";
                    OleDbConnection con = new OleDbConnection(conString);
                    OleDbCommand add = new OleDbCommand();
                    add.CommandType = System.Data.CommandType.Text;
                    add.CommandText = "delete " + logInfo + " where Item = '" + RemName + "';";
                    add.Connection = con;
                    con.Open();
                    add.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                database.RemoveByName(RemName);
                this.Close();
            }
        }

        private void RemNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameCheck = true;
        }
    }
}
