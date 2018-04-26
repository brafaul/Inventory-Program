using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Management_Program
{
    public class AddFac
    {
        TDatabase database;
        string logInfo;
        SolidColorBrush brush = Brushes.Snow;
        public AddFac(TDatabase D, string L, SolidColorBrush B)
        {
            database = D;
            logInfo = L;
            brush = B;
        }
        public AddWindow BuildWindow()
        {
            AddWindow add = new AddWindow(database, logInfo);
            add.Background = brush;
            return add;
        }
    }
}
