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
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Login.accdb";
            if (PassBox.Password.ToString() == PassBoxConfirm.Password.ToString() && PassBox.Password.Length != 0)
            {
                try
                {
                    OleDbConnection con = new OleDbConnection(conString);
                    OleDbCommand insert = new OleDbCommand();
                    insert.CommandType = System.Data.CommandType.Text;
                    insert.CommandText = "insert into Users ([Username], [Password]) values (?, ?);";
                    insert.Parameters.AddWithValue("@Username", UserBox.Text);
                    insert.Parameters.AddWithValue("@Password", PassBox.Password.ToString());

                    OleDbCommand addTable = new OleDbCommand();
                    addTable.CommandType = System.Data.CommandType.Text;
                    addTable.CommandText = "CREATE TABLE " + UserBox.Text + " (Item text, Quantity text, ID longtext);";

                    insert.Connection = con;
                    addTable.Connection = con;

                    con.Open();
                    insert.ExecuteNonQuery();
                    addTable.ExecuteNonQuery();
                    con.Close();

                    /*LoginDataSet set = new LoginDataSet();
                    set.Users.AddUsersRow(UserBox.Text, PassBox.Password.ToString());

                    LoginDataSetTableAdapters.UsersTableAdapter adap = new LoginDataSetTableAdapters.UsersTableAdapter();
                    adap.Update(set.Users);*/

                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Your Password is invalid or does not match.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
