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
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
        TDatabase database;
        int index;
        string tempAmount = null;
        string ID = null;
        int Amount;
        string Name = null;
        bool IndexCheck = false;
        bool ChangeCheck = false;
        public ModifyWindow()
        {
            InitializeComponent();
        }
        public ModifyWindow(TDatabase D)
        {
            database = D;
            InitializeComponent();
        }

        private void IDMBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ID = IDMBox.Text;
        }

        private void ATBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempAmount = ATBox.Text;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(ID != null)
            {
                index = database.FindIndexID(ID);
                IndexCheck = true;
            }
            if(tempAmount != null && IndexCheck)
            {
                bool result = int.TryParse(tempAmount, out Amount);
                if(result == false)
                {
                    MessageBox.Show("Error: Amount entered is not int");
                    ChangeCheck = true;
                }
                else
                {
                    database.GetElement(index).SetAmount(Amount);
                }
            }
            if (ChangeCheck)
            {
                DialogResult = true;
                this.Close();
            }
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name = NameBox.Text;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
