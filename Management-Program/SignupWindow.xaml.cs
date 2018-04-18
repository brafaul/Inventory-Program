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
            if (PassBox.Password.ToString() == PassBoxConfirm.Password.ToString())
            {
                LoginDataSetTableAdapters.UsersTableAdapter user = new LoginDataSetTableAdapters.UsersTableAdapter();
                LoginDataSet.UsersDataTable dt = user.GetDataByUsernamePassword(UserBox.Text, PassBox.Password.ToString());
                DialogResult = true;
            }
            else
                MessageBox.Show("Your Password does not match.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
