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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        string UserName;
        string PassWord;
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserName = UserBox.Text;
        }

        private void PassBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassWord = PassBox.Text;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //Heres where the code to add the user goes,
            //Probably also want to find a way to check for username repitition
            DialogResult = true;
            this.Close();

        }
    }
}
