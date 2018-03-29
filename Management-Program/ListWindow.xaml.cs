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
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        string current = null;
        TDatabase database;
        public ListWindow()
        {
            InitializeComponent();
        }
        public ListWindow(TDatabase D)
        {
            database = D;
            InitializeComponent();
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < database.Size(); i++)
            {
                current = null;
                current = database.GetElement(i).GetName() + " ";
                current = current + database.GetElement(i).GetAmount() + " ";
                current = current + database.GetElement(i).GetID() +  " " + "<LineBreak />";//Need to try and find way to seperate into lines
                ListBlock.Inlines.Add(current);
                ListBlock.Inlines.Add(new Line());
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
