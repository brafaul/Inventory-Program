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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public string N;
        public int Amount;
        public int ID;
        bool NameCheck = false;
        bool AmountCheck = false;
        bool IDCheck = false;
        public AddWindow()
        {
            InitializeComponent();
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            N = NameBox.Text;
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
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("One or more fields has not been filled out");
            }
        }
        private void AmountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string temp = AmountBox.Text;
            Amount = int.Parse(temp);
            AmountCheck = true;
        }

        private void NumBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string temp = NumBox.Text;
            ID = int.Parse(temp);
            IDCheck = true;
        }
    }
}
