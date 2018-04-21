//Name: AddWindow.xaml.cs
//Purpose: Add the functions to allow the user to add to the list that stores their database
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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public TDatabase database;
        //Internal database that gives the page to act on since it cannot interact with
        //the main window's directly
        public string N;
        public int Amount;
        public string ID;
        public string logInfo;
        bool NameCheck = false;
        //Makes sure the user entered in a name value
        bool AmountCheck = false;
        //Makes sure the user entered in an amount vaule
        bool IDCheck = false;
        //Makes sure the user has entered in an ID value
        public AddWindow(TDatabase D, string log)
        {
            //Constructor that makes the internal database equal to one on the page that calls it
            InitializeComponent();
            database = D;
            logInfo = log;
        }
        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameCheck = true;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameCheck == true && AmountCheck == true && IDCheck == true)
            {
                N = NameBox.Text;
                string ATemp = AmountBox.Text;
                bool result = int.TryParse(ATemp, out Amount);
                if (result == false)
                {
                    //Checks to see if user input for amount is an int
                    MessageBox.Show("Invalid Amount");
                }
                else
                {
                    ID = NumBox.Text;
                    if (database.Repetition(N, ID) == true)
                    {
                        //Checks for repeated name or ID number
                        MessageBox.Show("Cannot Repeat Name or ID");
                    }
                    else
                    {
                        try
                        {
                            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Login.accdb";
                            OleDbConnection con = new OleDbConnection(conString);
                            OleDbCommand add = new OleDbCommand();
                            add.CommandType = System.Data.CommandType.Text;
                            add.CommandText = "insert into " + logInfo + " (Item, Quantity, ID) VALUES (?, ?, ?);";
                            add.Parameters.AddWithValue("@Item", N);
                            add.Parameters.AddWithValue("@Quantity", Amount);
                            add.Parameters.AddWithValue("@ID", ID);
                            add.Connection = con;
                            con.Open();
                            add.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    DialogResult = true;
                    database.AddObject(N, Amount, ID);
                    this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("One or more fields has not been filled out");
            }
        }
        private void AmountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AmountCheck = true;
        }

        private void NumBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IDCheck = true;
        }
    }
}
