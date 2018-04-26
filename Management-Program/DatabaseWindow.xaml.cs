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
using System.Data;
using System.Configuration;
using System.Data.OleDb;

namespace Management_Program
{
    /// <summary>
    /// Interaction logic for DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        public string logInfo = null;
        string settingsColor = null;
        TDatabase database = new TDatabase();
        DataTable database2 = new DataTable();
        SolidColorBrush backColor = Brushes.Snow;
        public DatabaseWindow()
        {
            InitializeComponent();
        }
        public DatabaseWindow(string log, TDatabase db, string color, DataTable dt, SolidColorBrush B)
        {
            InitializeComponent();
            logInfo = log;
            database = db;
            database2 = dt;
            settingsColor = color;
            LoginLabel.Content += logInfo;
            backColor = B;
            BlockBuild();
            this.Background = backColor;
        }

        public void BlockBuild()
        {
            DataTable dt = new DataTable();
            string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Login.accdb";
            OleDbConnection con = new OleDbConnection(conString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from " + logInfo + ";";
            cmd.Connection = con;
            con.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();
            database2 = dt;
            BlockField block = new BlockField(dataGrid);
            ColorDecorator decorator = new ColorDecorator(settingsColor, block);
            dataGrid = decorator.Draw();
            dataGrid.ItemsSource = database2.DefaultView;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddFac fac = new AddFac(database, logInfo, backColor);
            AddWindow add = fac.BuildWindow();
            add.Owner = this;
            add.ShowDialog();
            if (add.DialogResult.HasValue && add.DialogResult.Value)
            {
                database = add.database;
                MessageBox.Show("Item " + add.N + " has been added");
                BlockBuild();
            }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            RemFac fac = new RemFac(database, logInfo, backColor);
            RemoveWindow rem = fac.BuildWindow();
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
            ModifyFac fac = new ModifyFac(database, logInfo, backColor);
            ModifyWindow mod = fac.BuildWindow();
            mod.Owner = this;
            mod.ShowDialog();
            if (mod.DialogResult.HasValue && mod.DialogResult.Value)
            {
                database = mod.database;
                BlockBuild();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        bool isClicked = false;
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (isClicked == false)
            {
                DataTable searchTable = database2;
                DataView dv = searchTable.DefaultView;
                dv.RowFilter = string.Format("Item like '%{0}%'", Search.Text);
                searchTable = dv.ToTable();
                dataGrid.ItemsSource = searchTable.DefaultView;

                Search_Button.Content = "Cancel";
                isClicked = true;
            }
            else if (isClicked == true)
            {
                Search.Text = String.Empty;
                DataTable searchTable = database2;
                DataView dv = searchTable.DefaultView;
                dv.RowFilter = string.Format("Item like '%{0}%'", Search.Text);
                searchTable = dv.ToTable();
                dataGrid.ItemsSource = searchTable.DefaultView;

                isClicked = false;
                Search_Button.Content = "Search";
            }
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DataTable searchTable = database2;
                DataView dv = searchTable.DefaultView;
                dv.RowFilter = string.Format("Item like '%{0}%'", Search.Text);
                searchTable = dv.ToTable();
                dataGrid.ItemsSource = searchTable.DefaultView;

                Search_Button.Content = "Cancel";
                isClicked = true;
            }
            if(e.Key == Key.Escape)
            {
                Search.Text = String.Empty;
                DataTable searchTable = database2;
                DataView dv = searchTable.DefaultView;
                dv.RowFilter = string.Format("Item like '%{0}%'", Search.Text);
                searchTable = dv.ToTable();
                dataGrid.ItemsSource = searchTable.DefaultView;

                isClicked = false;
                Search_Button.Content = "Search";
            }
        }
    }
}
