using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Management_Program
{
    public class SetFac
    {
        string blockColor;
        SolidColorBrush brush;
        public SetFac(string B, SolidColorBrush Br)
        {
            blockColor = B;
            brush = Br;
        }
        public SettingsWindow BuildWindow()
        {
            SettingsWindow set = new SettingsWindow(blockColor, brush);
            set.Background = brush;
            return set;
        }

    }
}
