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
    /// Interaction logic for DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        public SolidColorBrush BackColor = Brushes.Snow;
        public string logInfo = null;
        string settingsColor = null;
        TDatabase database = new TDatabase();

        public DatabaseWindow()
        {
            InitializeComponent();
        }
        public DatabaseWindow(string log, TDatabase db, string color, SolidColorBrush brush)
        {
            InitializeComponent();
            logInfo = log;
            database = db;
            settingsColor = color;
            LoginLabel.Content += logInfo;
            BackColor = brush;
            this.Background = BackColor;
            BlockBuild();
        }

        public void BlockBuild()
        {
            BlockField block = new BlockField(ListBlock);
            TextDecorator dec = new TextDecorator(block, database);
            ColorDecorator dec2 = new ColorDecorator(settingsColor, block);
            ListBlock = dec.Draw();
            ListBlock = dec2.Draw();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddFac fac = new AddFac(database, logInfo, BackColor);
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
            RemFac fac = new RemFac(database, logInfo, BackColor);
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
            ModifyFac fac = new ModifyFac(database,logInfo,BackColor);
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
    }
}
