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
        public RemoveWindow()
        {
            InitializeComponent();
        }
        public RemoveWindow(TDatabase D)
        {
            database = D;
            InitializeComponent();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameCheck == true)
            {
                RemName = RemNameBox.Text;
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
