//Name:MainWindow.xaml.cs
//Purpose: Establishes back logic for main window 
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Management_Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool logCheck = false;
        TDatabase database = new TDatabase();
        public void BlockBuild()
        {
            BlockField block = new BlockField(ListBlock);
            TextDecorator dec = new TextDecorator(block, database);
            ListBlock = dec.Draw();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (logCheck)
            {
                MessageBox.Show("User is already logged in");
            }
            else
            {
                LoginWindow log = new LoginWindow();
                log.Owner = this;
                log.ShowDialog();
                if (log.DialogResult.HasValue && log.DialogResult.Value)
                {
                    MessageBox.Show("Welcome " + log.Username);
                    UserBox.Text = "Logged in as " + log.Username;
                    BlockBuild();
                    logCheck = true;
                }
                //else
                    //this.Close();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow(database);
            add.Owner = this;
            add.ShowDialog();
            if(add.DialogResult.HasValue && add.DialogResult.Value)
            {
                database = add.database;
                MessageBox.Show("Item " + add.N + " has been added");
                BlockBuild();
            }
        }
        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveWindow rem = new RemoveWindow(database);
            rem.Owner = this;
            rem.ShowDialog();
            if (rem.DialogResult.HasValue && rem.DialogResult.Value)
            {
                database = rem.database;
                BlockBuild();
            }
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {
            ModifyWindow mod = new ModifyWindow(database);
            mod.Owner = this;
            mod.ShowDialog();
            if(mod.DialogResult.HasValue && mod.DialogResult.Value)
            {
                database = mod.database;
                BlockBuild();
            }
        }

        private void List_Button_Click(object sender, RoutedEventArgs e)
        {
            //This just updates the list in the case an unforseen circumstance
            //Makes the user think it is not correct
            BlockBuild();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow();
            set.Owner = this;
            set.ShowDialog();
            if(set.DialogResult.HasValue && set.DialogResult.Value)
            {
                if(set.BlockColor != null)
                {
                    BlockField block = new BlockField(ListBlock);
                    ColorDecorator dec = new ColorDecorator(set.BlockColor, block);
                    ListBlock = dec.Draw();
                }
            }
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
