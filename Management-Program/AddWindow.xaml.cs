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
        public TDatabase database;
        public string N;
        public int Amount;
        public string ID;
        bool NameCheck = false;
        bool AmountCheck = false;
        bool IDCheck = false;
        public AddWindow()
        {
            InitializeComponent();
        }
        public AddWindow(TDatabase D)
        {
            database = D;
            InitializeComponent();
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
                if(result == false)
                {
                    MessageBox.Show("Invalid Amount");
                }
                ID = NumBox.Text;
                DialogResult = true;
                database.AddObject(N, Amount, ID);
                this.Close();
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
