using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Management_Program
{
    public class RemFac
    {
        TDatabase database;
        string logInfo;
        SolidColorBrush brush;
        public RemFac(TDatabase D, string L, SolidColorBrush B)
        {
            database = D;
            logInfo = L;
            brush = B;
        }
        public RemoveWindow BuildWindow()
        {
            RemoveWindow rem = new RemoveWindow(database, logInfo);
            rem.Background = brush;
            return rem;
        }
    }
}
