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
        TDatabase database = new TDatabase();
        public void BlockBuild()
        {
            BlockField block = new BlockField(ListBlock);
            BlockDecorator dec = new BlockDecorator(block, database);
            ListBlock = dec.Draw();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow log = new LoginWindow();
            log.Owner = this;
            log.ShowDialog();
            if (log.DialogResult.HasValue && log.DialogResult.Value)
            {
                MessageBox.Show("Welcome " + log.Username);
                UserBox.Text = "Logged in as " + log.Username;
                BlockBuild();
            }
            else
                this.Close();
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
            database = rem.database;
            BlockBuild();
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
