﻿//Name: ModifyWindow.xaml.cs
//Purpose: Adds background functionality for the Modify Window
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
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
        public TDatabase database;
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
            if(ID != null && Name == null)
            {
                index = database.FindIndexID(ID);
                IndexCheck = true;
            }
            if(Name != null && ID == null)
            {
                index = database.FindIndexName(Name);
                IndexCheck = true;
            }
            if(ID != null && Name != null)
            {
                if(database.FindIndexID(ID) == database.FindIndexName(Name))
                {
                    index = database.FindIndexID(ID);
                    IndexCheck = true;
                }
                else
                {
                    MessageBox.Show("Error: ID and Name do not match");
                }
            }
            if(tempAmount != null && IndexCheck)
            {
                bool result = int.TryParse(tempAmount, out Amount);
                //Checks to see if the amount entered into the
                //amountbox is in infact an integer
                if(result == false)
                {
                    MessageBox.Show("Error: Amount entered is not int");
                }
                else
                {
                    database.GetElement(index).SetAmount(Amount);
                    ChangeCheck = true;
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